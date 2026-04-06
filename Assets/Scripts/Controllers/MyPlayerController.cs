using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : CreatureController
{
	protected override void Init()
	{
		base.Init();
	}

	protected override void UpdateController()
	{
		GetUIKeyInput();

		base.UpdateController();
	}

	protected override void UpdateIdle()
	{
	}

	void LateUpdate()
	{
		Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}

	void GetUIKeyInput()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
		}
		else if (Input.GetKeyDown(KeyCode.C))
		{
		}
	}

	// 키보드 입력
	void GetDirInput()
	{
		if (Input.GetKey(KeyCode.W))
		{
		}
		else if (Input.GetKey(KeyCode.S))
		{
		}
		else if (Input.GetKey(KeyCode.A))
		{
		}
		else if (Input.GetKey(KeyCode.D))
		{
		}
	}
}
