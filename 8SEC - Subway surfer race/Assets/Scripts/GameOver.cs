using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameOver : MonoBehaviour
{
	public CarController Carcontroller;
	public CarStat Carstat;
	public int ResCost;
	GameManager GM;
	public FloorSpawner floorSpawner;

	public GameOverUI GameOverUI;
	public Score score;
	public PlayableDirector CameraTransition;
	public AudioSource GameMusic;
	public ChronoStartGame chrono;

	public bool IsEnoughtLife()
	{
	
		if (GameManager.instance.life >= ResCost)
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
		Carstat.Respawn();
		//floorSpawner.ResetPattern();
		GameOverUI.DiseableGameOverUI();
	}

	public void Resume()
	{
		RessurectPlayer();
		GameManager.instance.life -= ResCost;
		ResCost += 1;
		chrono.StartChrono();
	}

	public void ResetGame()
	{
		RessurectPlayer();
		score.ResetScore();
		chrono.StartChrono();
	}

	public void ReturnToMainMenu()
	{
		floorSpawner.RestAndStopRoad();
		GameOverUI.DiseableGameOverUI();
		CameraTransition.Play();
	}

	public void EnableGameOver()
	{
		GameMusic.Stop();
		GameOverUI.EnableUIGameOver();
	}

	public void OnContinueButtonPressed()
	{
		Resume();
	}

	public void OnResetButtonPressed()
	{
		ResetGame();
	}

	public void OnReturnToMainMenuButtonPressed()
	{
		ReturnToMainMenu();
	}

}
