using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : CollectibleObject
{
	public int  MultiplicatorValue = 0;
	
	public override void UseBonus(GameObject other)
	{
		base.UseBonus(other);
		other.GetComponentInChildren<BonusCaller>().CallMultiplicator(MultiplicatorValue, Duration);
		//	other.GetComponentInParent<Score>().AddMultiplicatorValue(MultiplicatorValue);
	}
}
