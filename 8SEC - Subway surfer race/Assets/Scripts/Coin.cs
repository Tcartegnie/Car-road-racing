using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : CollectibleObject
{
	public int Value;
	public override void UseBonus(GameObject other)
	{
		other.GetComponentInChildren<Score>().AddScore(Value);
	}
}
