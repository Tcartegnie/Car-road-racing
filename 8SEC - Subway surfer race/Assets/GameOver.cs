using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	public CarController Carcontroller;
	public CarStat Carstat;
	public int ResCost;
	GameManager GM;
	public FloorSpawner floorSpawner;

	public GameOverUI GMUI;
	public Score score;


	public void Start()
	{
		GM = GameManager.instance;
	}

	public bool IsEnoughtLife()
	{
		if (GM.Life >= ResCost)
		{
			return true; 
		}
		else
		{
			return false;
		}
	}

	public void RessurectPlayer()
	{
		Carcontroller.ResetPosition();
		floorSpawner.ResetPattern();
		GMUI.DiseableUIGameOver();
		Carstat.Respawn();

	}

	public void Resume()
	{
		RessurectPlayer();
		GM.life -= ResCost;
		ResCost += 1;
	}

	public void ResetGame()
	{
		RessurectPlayer();
		score.ResetScore();
	}

	public void OnContinueButtonPressed()
	{
		Resume();
	}

	public void OnResetButtonPressed()
	{
		ResetGame();
	}


}
