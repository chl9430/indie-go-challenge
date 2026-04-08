using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
