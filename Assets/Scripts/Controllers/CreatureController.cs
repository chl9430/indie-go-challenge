using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using static Define;

public class CreatureController : BaseController
{
	protected override void Init()
	{
		base.Init();
	}

	public virtual void OnDamaged()
	{
	}

	public virtual void OnDead()
	{
	}

	public virtual void UseSkill(int skillId)
	{
	}
}
