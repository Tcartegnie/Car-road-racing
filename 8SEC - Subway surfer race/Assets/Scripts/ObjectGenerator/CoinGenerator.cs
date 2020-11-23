using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : ObjectGenerator
{
	private Score score;
	public int CoinNumber;
	public float SpaceBetweenCoin;

	public Score Score { get => score; set => score = value; }

	public void GenerateCoins(RoadSegements segement)
	{
		for (int i = 0; i < segement.Train.Length; i++)
		{
			if (segement.IsCoinSpawner[i])
			{
				if (Random.Range(0, 2) == 1)
				{
					if (segement.Train[i])//Check if there is on train on this lane
					{//If true we set the coins position over the train
						for (int j = 0; j < CoinNumber; j++)
						{
							CreateCoin(i, (Spawns[i].up * 7) + (Spawns[i].forward * -(SpaceBetweenCoin * j)));
						}
					}
					else//If there is no train
					{//We set the coin, at the normal position
						for (int j = 0; j < CoinNumber; j++)
						{
							CreateCoin(i, Spawns[i].forward * -(SpaceBetweenCoin * j));
						}
					}
				}
			}
		}
	}
	public void CreateCoin(int SpawnID,Vector3 offset)
	{
		GameObject GO = GenerateObject("Coin", SpawnID, (offset));
		GO.GetComponent<Coin>().Score = Score;
	}

}
