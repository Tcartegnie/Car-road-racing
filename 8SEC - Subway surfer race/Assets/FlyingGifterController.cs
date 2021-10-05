using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGifterController : MonoBehaviour
{
    Chrono chrono;
	public SwapLine swap;
	public int RandomRate;
	public BonusSpawner spawner;

	public void Start()
	{
		chrono = new Chrono (10.0f);
		chrono.OnEndChrono += OnEndChrono;
		chrono.StartChrono();
	}

	public void Update()
	{
		chrono.PlayChrono();
	}

	public void SpawnRandomObject()
	{
		if(Random.Range(0,100) <= RandomRate)
		{
		GameObject GO =	spawner.SpawnBonusOnPosition();
		GO.GetComponentInChildren<CollectibleObject>().EnableGravity();
		}
	}

	public void SwapOnRandomLine()
	{
		swap.GoOnRandomLine();
	}

	public void OnEndChrono()
	{
		SpawnRandomObject();
		SwapOnRandomLine();
		chrono.StartChrono();
	}

}
