using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : ObjectGenerator
{

	public void Start()
	{
		SpawnBonus();
	}
	
	public BonusList bonusList;
	public void SpawnBonus()
	{
		for (int i = 0; i < Spawns.Count; i++)
		{
			BonusData data = bonusList.GetRandomBonus();
			if (Random.Range(0, data.RandomRate) == 1)
			{
				GenerateObject("Bonus" + data.Name,i, Spawns[i].position);
			}
		}
	}


	
}
