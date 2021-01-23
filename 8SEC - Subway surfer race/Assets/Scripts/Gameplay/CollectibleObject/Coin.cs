using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : CollectibleObject
{
	Score score;
	public int Value;
	public int CoinNumber;

	public Score Score { get => score; set => score = value; }

	public override void UseBonus(GameObject other)
	{
		base.UseBonus(other);
		Score.AddScoreByMultiplicator(Value);
		Score.AddCoin(CoinNumber);
	}
	
}
