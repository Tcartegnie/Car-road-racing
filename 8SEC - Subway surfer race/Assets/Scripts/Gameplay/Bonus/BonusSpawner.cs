using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BonusSpawner : ObjectGenerator
{

	public void Start()
	{
		SpawnRandomBonusOnLine();
	}
	
	public BonusList bonusList;
	public void SpawnRandomBonusOnLine()
	{
		for (int i = 0; i < Spawns.Count; i++)
		{
			BonusData data = bonusList.GetRandomBonus();
			if (Random.Range(0, data.RandomRate) == 1)
			{
				GenerateObject(data.Name,i, Spawns[i].position);
			}
		}
	}

	public GameObject SpawnBonusOnPosition()
	{
			BonusData data = bonusList.GetRandomBonus();
			GameObject GO = GenerateObject(data.Name, transform.position);
			return GO;
			
	}

}
