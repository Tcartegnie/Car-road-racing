using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
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
		GM.life -= ResCost;
		floorSpawner.ResetPattern();
		GMUI.DiseableUIGameOver();
		Carstat.Respawn();
		ResCost += 1;
	}

	public void ResetGame()
	{
		score.ResetScore();
		floorSpawner.ResetPattern();
		GMUI.DiseableUIGameOver();
		Carstat.Respawn();

	}

	public void OnContinueButtonPressed()
	{
		RessurectPlayer();
	}

	public void OnResetButtonPressed()
	{
		ResetGame();
	}


}
