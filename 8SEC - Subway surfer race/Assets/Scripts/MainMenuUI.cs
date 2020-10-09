using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MainMenuUI : MonoBehaviour
{
    public GameObject MainMenuCamera;
    public GameObject MainGameCamera;
    public ChronoStartGame ChronoStartGame;
    public AudioSource MainMenuMusic;
    public AudioSource InGameMusic;
    public AudioSource StartSound;
    public GameObject OptionScreen;
    public PlayableDirector TransitionToGame;
    public RectTransform MainMenu;


    public void StartGame()
    { 
        TurnToGameCamera();
        ChronoStartGame.gameObject.SetActive(true);
        ChronoStartGame.StartChrono();
    }


    public void TurnToGameCamera()//Maybe go on a camera script ?
	{
        MainGameCamera.SetActive(true);
        MainMenuCamera.SetActive(false);
    }

    public void TurnToMenuCamera()//Maybe go on a camera script ?
	{
        MainGameCamera.SetActive(false);
        MainMenuCamera.SetActive(true);
    }
    
    public void TurnOnStartScreen()
	{
        TurnOnMainMenuUI();
        MainMenuMusic.Play();
    }

    public void TurnOnMainMenuUI()
	{
        MainMenu.gameObject.SetActive(true);
    }

    public void TurnOffMainMenuUI()
	{
        MainMenu.gameObject.SetActive(false);
    }

    public void OnStartButtonPressed()
	{
        StartSound.Play();
        MainMenuMusic.Stop();
        TransitionToGame.Play();
        TurnOffMainMenuUI();
    }
    
    public void OnScoreButtonPressed()
	{

	}

    public void OnOptionButtonPressed()
	{
        TurnOffMainMenuUI();
        OptionScreen.SetActive(true);

    }

    public void OnQuitGame()
	{
        ReturnToMainMenu();
	}

    public void ReturnToMainMenu()
	{
        InGameMusic.Stop();
        MainMenuMusic.Play();
        TurnToMenuCamera();
        TurnOnMainMenuUI();
    }

    public void QuitApplication()
	{
        Application.Quit();
	}

}
