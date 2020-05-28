using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

	public Transform SpawnRoad;
	public GameObject CurrentModel;
	public void ChangeRoadPattern(GameObject roadPreafb)
	{
		if(CurrentModel !=null)
		{
			CurrentModel.GetComponent<CoinSpawner>().RemoveCoin();
			Destroy(CurrentModel.gameObject);
		}

		CurrentModel = Instantiate(roadPreafb, SpawnRoad,false);
		CurrentModel.GetComponent<CoinSpawner>().SpawnCoins();
		CurrentModel.GetComponent<CoinSpawner>().SpawnBonus();
	}

}
