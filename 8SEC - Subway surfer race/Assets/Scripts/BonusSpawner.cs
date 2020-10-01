using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{

	public void Start()
	{
		SpawnBonus();
	}

	List<GameObject> CurrentObjects = new List<GameObject>();
	public List<Transform> BonusSpawn = new List<Transform>();
	public BonusList bonusList;
	public void SpawnBonus()
	{
		for (int i = 0; i < BonusSpawn.Count; i++)
		{
			BonusData data = bonusList.GetRandomBonus();
			if (Random.Range(0, data.RandomRate) == 1)
			{
				GameObject go = ObjectPooler.instance.SpawnFromPool("Bonus" + data.Name, new Vector3(BonusSpawn[i].position.x, BonusSpawn[i].position.y, BonusSpawn[i].position.z), new Quaternion());
				go.transform.SetParent(transform, true);
				CurrentObjects.Add(go);
			}
		}
	}


	public void RemoveBonus()
	{
		for (int i = 0; i < CurrentObjects.Count; i++)
		{
			CurrentObjects[i].SetActive(false);
			CurrentObjects[i].transform.SetParent(null);
		}
		CurrentObjects.Clear();
	}
}
