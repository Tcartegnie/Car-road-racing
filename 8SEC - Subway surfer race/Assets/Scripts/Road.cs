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
			if (CurrentModel.GetComponent<CoinSpawner>())
			{
				CurrentModel.GetComponent<CoinSpawner>().RemoveCoin();//Refacto
			}
			Destroy(CurrentModel.gameObject);
		}

		CurrentModel = Instantiate(roadPreafb, SpawnRoad,false);
		//CurrentModel.GetComponent<CoinSpawner>().SpawnCoins();
		//CurrentModel.GetComponent<CoinSpawner>().SpawnBonus();
	}

}
