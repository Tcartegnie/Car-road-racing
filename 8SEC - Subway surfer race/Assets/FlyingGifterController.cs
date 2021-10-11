using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGifterController : MonoBehaviour
{
    Chrono chrono;
    Chrono Duration;

	public float SwapCooldown;
	public float FlyingDuration;

	public float MaxCoolDown;
	public float MinCoolDown;

	public float EntranceDuration;
	public SwapLine swap;
	public int RandomRate;
	public BonusSpawner spawner;

	bool EnableBehaviour;

	public void Start()
	{
		chrono = new Chrono (SwapCooldown);
		chrono.OnEndChrono += OnEndChrono;
		

		Duration = new Chrono(FlyingDuration);
		Duration.OnEndChrono += CallExit;
		

		EnableBehaviour = false;
	}

	void EnableGiftDistrubution()
	{
		chrono.StartChrono();
		Duration.StartChrono();
		EnableBehaviour = true;
	}

	public void Update()
	{
	
		if (EnableBehaviour)
		{
			Duration.PlayChrono();
			chrono.PlayChrono();
		}

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
		if (EnableBehaviour)
		{
			SpawnRandomObject();
			SwapOnRandomLine();
			chrono.StartChrono();
		}
	}

	public void CallEntranceInScene()
	{
		StartCoroutine(Entrance());
	}

	public void CallExit()
	{
		swap.CallStopAllCoroutine();
		StartCoroutine(Exit());
	}

	public IEnumerator Entrance()
	{
		yield return StartCoroutine(swap.SwapToLine(swap.GetRandomLanePosition(),new Vector3(0,0,100),EntranceDuration));
		EnableGiftDistrubution();
	}

	public IEnumerator Exit()
	{
		EnableBehaviour = false;
		yield return StartCoroutine(swap.SwapToLine(new Vector3(0,30f,20f), EntranceDuration));
	}
}
