using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
	public int Id { get; set; }

	protected Animator _animator;
	protected SpriteRenderer _sprite;

	protected virtual void UpdateAnimation()
	{
		if (_animator == null || _sprite == null)
			return;
	}

	void Start()
	{
		Init();
	}

    protected virtual void Init()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();

        UpdateAnimation();
    }

    void Update()
	{
		UpdateController();
	}

	protected virtual void UpdateController()
	{
	}

	protected virtual void UpdateIdle()
	{
	}

	protected virtual void UpdateMoving()
	{
	}

	protected virtual void UpdateSkill()
	{
	}

	protected virtual void UpdateDead()
	{
	}
}
