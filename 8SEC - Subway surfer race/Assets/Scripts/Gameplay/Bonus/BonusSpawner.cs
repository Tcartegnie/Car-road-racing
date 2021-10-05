using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BonusSpawner : ObjectGenerator
{

	public void Start()
	{
		SpawnBonusOnLine();
	}
	
	public BonusList bonusList;
	public void SpawnBonusOnLine()
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

	public void SpawnBonusOnPosition()
	{
			BonusData data = bonusList.GetRandomBonus();
			if (Random.Range(0, data.RandomRate) == 1)
			{
				GameObject GO =	GenerateObject(data.Name, 0, Vector3.zero);
				GO.AddComponent<MovingObject>();
			}	
	}


	
}
