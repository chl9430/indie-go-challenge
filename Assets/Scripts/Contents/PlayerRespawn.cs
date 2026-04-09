using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float respawnDelay = 1f;

    private Rigidbody2D rb;
    private MyPlayerController controller;
    private bool isDead;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<MyPlayerController>();

        transform.position = respawnPoint.position;
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        controller.enabled = false;
        rb.linearVelocity = Vector2.zero;

        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnDelay);

        transform.position = respawnPoint.position;

        controller.enabled = true;
        isDead = false;
    }

    public void SetRespawnPoint(Transform newPoint)
    {
        respawnPoint = newPoint;
    }
}
