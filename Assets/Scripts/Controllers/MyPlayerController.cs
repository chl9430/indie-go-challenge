using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class MyPlayerController : CreatureController
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float acceleration = 15f;
    [SerializeField] private float deceleration = 20f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float coyoteTime = 0.1f;
    [SerializeField] private float jumpBufferTime = 0.1f;
    [SerializeField] private float fallGravityMultiplier = 2f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;

    private Vector2 moveInput;
    private bool jumpPressed;

    private bool isGrounded;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    protected override void Init()
	{
		base.Init();

        rb = GetComponent<Rigidbody2D>();
    }

	protected override void UpdateController()
	{
		base.UpdateController();

        CheckGround();

        HandleTimers();
        HandleJumpBuffer();
        HandleJump();

        ApplyBetterGravity();
        FlipSprite();
    }

	protected override void UpdateIdle()
	{
	}

    void FixedUpdate()
    {
        HandleMovement();
    }

    void LateUpdate()
	{
		Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpPressed = true;
            jumpBufferCounter = jumpBufferTime;
        }

        //if (context.canceled && rb.linearVelocity.y > 0f)
        //{
        //    rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        //}
    }

    private void HandleMovement()
    {
        float targetSpeed = moveInput.x * moveSpeed;
        float speedDifference = targetSpeed - rb.linearVelocity.x;

        float accelRate = Mathf.Abs(targetSpeed) > 0.01f ? acceleration : deceleration;

        float movement = speedDifference * accelRate;

        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x + movement * Time.fixedDeltaTime,
            rb.linearVelocity.y
        );
    }

    private void HandleJump()
    {
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            jumpBufferCounter = 0f;
            coyoteTimeCounter = 0f;
        }
    }

    private void HandleTimers()
    {
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        jumpBufferCounter -= Time.deltaTime;
    }

    private void HandleJumpBuffer()
    {
        if (jumpPressed)
        {
            jumpPressed = false;
        }
    }

    private void ApplyBetterGravity()
    {
        if (rb.linearVelocity.y < 0f)
        {
            rb.gravityScale = fallGravityMultiplier;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
    }

    private void FlipSprite()
    {
        if (moveInput.x > 0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (moveInput.x < -0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
