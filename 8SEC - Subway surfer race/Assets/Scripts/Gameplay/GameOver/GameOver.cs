using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameOver : MonoBehaviour
{
	public CarController Carcontroller;
	public CarStat Carstat;
	public int ResCost;
	public FloorSpawner floorSpawner;

	public GameOverUI GameOverUI;
	public Score score;
	public PlayableDirector CameraTransition;
	public AudioSource GameMusic;
	public ChronoStartGame chrono;
	public EndGame EndGameMenu;
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

	public void RestartRoad()
	{
		floorSpawner.ResetPattern();
		floorSpawner.EnableMoveRoad();
	}

	public void Resume()
	{
		RessurectPlayer();
		GameManager.instance.life -= ResCost;
		ResCost += 1;
		chrono.StartChrono();
		RestartRoad();
	}

	public void ResetGame()
	{
		RessurectPlayer();
		score.ResetScore();
		chrono.StartChrono();
		RestartRoad();
	}

	public void ReturnToMainMenu()
	{
		GameOverUI.DiseableGameOverUI();
		EndGameMenu.gameObject.SetActive(true);
		EndGameMenu.PlayDisplayScore();
		score.SavePlayerProgress();
	}

	public void EnableGameOver()
	{
		GameMusic.Stop();
		GameOverUI.EnableUIGameOver();
		//floorSpawner.DisableMoveRoad();
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
