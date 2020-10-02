using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : CollectibleObject
{
	public AudioClip test;
	public AudioSource CoinNoise;
	public int Value;
	public override void UseBonus(GameObject other)
	{
		other.GetComponentInParent<Score>().AddScore(Value);
		CoinNoise.PlayOneShot(test);
	}
}
