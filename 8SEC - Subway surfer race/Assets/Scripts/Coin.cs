using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : CollectibleObject
{
	public int Value;
	public override void UseBonus(GameObject other)
	{
		other.GetComponentInParent<Score>().AddScore(Value);
	}
}
