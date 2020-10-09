using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoStartGame : MonoBehaviour
{
	public ChronoStartScreen ChronoStartScreen;
	public FloorSpawner FloorSpawner;
	public CarStat state;
	public InGameUI InGameUI;
	public float StartTime;
	GameManager GM;
	public AudioSource ChronoSound;
	public AudioSource GameMusic;
	public void Start()
	{
		GM = GameManager.instance;
	}

	public void StartChrono()
	{
		ChronoStartScreen.TurnOn();
		GM.OnPause = true;
		FloorSpawner.InitSpawn();
		StartCoroutine(StartScreen());
	}

	void StartGame()
	{
		state.InitCar();
		GM.OnPause = false;
		FloorSpawner.SpawnCamionEnable = true;
		InGameUI.TurnOnUI();
		GameMusic.Play();
	}

	IEnumerator StartScreen()
	{
		yield return StartCoroutine(Chrono());
		yield return StartCoroutine(ChronoStartScreen.PlayGoScreenDisplay());
		StartGame();
		
	}
	IEnumerator Chrono()
	{
		for(int i = 3; i > 0;i--)
		{

			ChronoStartScreen.SeTChronoText((i).ToString());
			ChronoSound.Play();
			yield return new WaitForSeconds(1);
		
		}
		ChronoStartScreen.SeTChronoText("GO");

	}
}
