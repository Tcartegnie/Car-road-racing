using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : CollectibleObject
{
	public override void UseBonus(GameObject other)
	{
		GameManager.instance.Life += 1;
	}
}
