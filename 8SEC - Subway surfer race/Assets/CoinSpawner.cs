using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoinSpawnData
{

}
public class CoinSpawner : MonoBehaviour
{

	List<GameObject> CurrentObjects = new List<GameObject>();
	public int CoinNumber;
	public int SpaceBetweenCoin;
	public List<Transform> CoinsSpawners = new List<Transform>();
	public List<Transform> BonusSpawner = new List<Transform>();

	public BonusList bonusList;

	public void Start()
	{
		SpawnCoins();
		SpawnBonus();
	}

	public void SpawnBonus()
	{
		for (int i = 0; i < BonusSpawner.Count; i++)
		{
			BonusData data = bonusList.GetRandomBonus();
			if (Random.Range(0, data.RandomRate) == 1)
			{
				GameObject GO = ObjectPooler.instance.SpawnFromPool("Bonus" + data.Name, new Vector3(BonusSpawner[i].position.x, BonusSpawner[i].position.y, BonusSpawner[i].position.z), new Quaternion());
				GO.transform.SetParent(transform, true);
				CurrentObjects.Add(GO);
			}
		}
	}

	public void SpawnCoins()
	{
		

		for (int i = 0; i < CoinsSpawners.Count; i++)
		{
			int RandomResult = Random.Range(0, 2);
			if (RandomResult == 1)
			{
				for (int j = 0; j < CoinNumber; j++)
				{
					GameObject GO = ObjectPooler.instance.SpawnFromPool("Coin", new Vector3(CoinsSpawners[i].position.x, CoinsSpawners[i].position.y, CoinsSpawners[i].position.z - (SpaceBetweenCoin * j)), new Quaternion());
					GO.transform.SetParent(transform, true);
					CurrentObjects.Add(GO);
				}
			}
		}
	}

	public void RemoveCoin()
	{
		for(int i = 0; i < CurrentObjects.Count;i++)
		{
			CurrentObjects[i].SetActive(false);
			CurrentObjects[i].transform.SetParent(null);
		}
		CurrentObjects.Clear();
	}

}
