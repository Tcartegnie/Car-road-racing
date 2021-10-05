using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGifterController : MonoBehaviour
{
    public Chrono chrono;
	public SwapLine swap;
	public int RandomRate;
	public BonusSpawner spawner;
	public void Start()
	{
		chrono.OnEndChrono += OnEndChrono;
		chrono.StartChrono();
	}


	public void SpawnRandomObject()
	{
		if(Random.Range(0,100) <= RandomRate)
		{
			spawner.SpawnBonusOnPosition();
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
