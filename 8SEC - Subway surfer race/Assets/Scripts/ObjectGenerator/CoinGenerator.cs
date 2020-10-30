using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : ObjectGenerator
{
	public int CoinNumber;
	public float SpaceBetweenCoin;

	public void GenerateCoins()
	{
		for (int i = 0; i < Spawns.Count; i++)
		{
			//int RandomResult = Random.Range(0, 2);
			//if (RandomResult == 1)
			//{
				for (int j = 0; j < CoinNumber; j++)
				{
					GenerateObject("Coin",i, Spawns[i].forward * -(SpaceBetweenCoin * j));
				}
			//}
		}
	}

}
