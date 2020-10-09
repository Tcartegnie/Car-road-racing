using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

	public Transform SpawnRoad;
	public GameObject CurrentModel;
	public GameObject Building;
	public void ChangeRoadPattern(GameObject roadPrefab, Transform TR)
	{
		if(CurrentModel !=null)
		{
			if (CurrentModel.GetComponent<CoinSpawner>())
			{
				CurrentModel.GetComponent<CoinSpawner>().RemoveCoin();//Refacto
			}
			Destroy(CurrentModel);
			//Destroy(Building);
		}

		CurrentModel = Instantiate(roadPrefab, SpawnRoad);
		//CurrentModel.GetComponent<CoinSpawner>().SpawnCoins();
		//CurrentModel.GetComponent<CoinSpawner>().SpawnBonus();
	}

}
