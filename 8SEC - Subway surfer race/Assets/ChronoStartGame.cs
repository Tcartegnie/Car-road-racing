using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoStartGame : MonoBehaviour
{
	public ChronoStartScreenUI ChronoStartScreen;
	public FloorSpawner FloorSpawner;
	public CarStat state;
	public float StartTime;

	public void Start()
	{
	
	}

	public void StartChrono()
	{
		FloorSpawner.InitSpawn();
		StartCoroutine(StartScreen());
	}

	void StartGame()
	{
		state.InitCar();
		ChronoStartScreen.TurnOff();
		FloorSpawner.SpanwCamionEnable = true;
	}

	IEnumerator StartScreen()
	{
		yield return StartCoroutine(Chrono());
		yield return StartCoroutine(ChronoStartScreen.PlayGoScreenDisplay());
		StartGame();
	}

	IEnumerator Chrono()
	{
		for(float i = StartTime; i >= 0; i-= Time.deltaTime )
		{
			int IntI = (int)i;
			ChronoStartScreen.SeTChronoText((IntI+1).ToString());
			yield return null;
		}
		ChronoStartScreen.SeTChronoText("0");
	}
}
