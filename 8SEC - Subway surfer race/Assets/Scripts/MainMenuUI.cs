using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    GameManager GM;
    public GameObject MainMenuCamera;
    public GameObject MainGameCamera;
    public ChronoStartGame ChronoStartGame;
    public AudioSource MainMenuMusic;
    public AudioSource InGameMusic;
    public AudioSource StartSound;

    public PlayableDirector TransitionToGame;
    [Space]
    public GameObject MainMenu;
    public GameObject ShopMenu;
    public GameObject OptionScreen;

    public Text HightScore;
    public Text CoinCount;
    public ScoreSaveData scoreSavedata;

    public ScoreDisplayer scoreDisplayer;
    public Score scoreMenu;
    public ShopMenu shopmenu;

	public void Start()
	{
        GM = GameManager.Instance();
        SetHigtScore();
	}
	public void StartGame()
    { 
        TurnToGameCamera();
        ChronoStartGame.gameObject.SetActive(true);
        ChronoStartGame.StartChrono();
        scoreDisplayer.RefreshScore();
        scoreMenu.ResetScore();
        scoreMenu.ResetMultiplicator();
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
        scoreDisplayer.RefreshScore();
    }

    public void TurnOnMainMenuUI()
	{
        MainMenu.SetActive(true);
    }

    public void TurnOffMainMenuUI()
	{
        MainMenu.SetActive(false);
    }

    public void OnStartButtonPressed()
	{
        GM.SetPause(true);
        StartSound.Play();
        MainMenuMusic.Stop();
        TransitionToGame.Play();
        TurnOffMainMenuUI();
    }
    
    public void OnScoreButtonPressed()
	{
        ShopMenu.SetActive(true);
        ShopMenu.GetComponent<ShopMenuUI>().RefreshCoinDisplayer();
        TurnOffMainMenuUI();
        shopmenu.InitShop();
    }

    public void OnOptionButtonPressed()
	{
        TurnOffMainMenuUI();
        OptionScreen.SetActive(true);
    }


    public void SetHigtScore()
	{
        HightScore.text = scoreSavedata.GetHigtScore().ToString();
    }

    public void SetCoinCout()
	{
        CoinCount.text = scoreSavedata.GetCoinValue().ToString();

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
        scoreDisplayer.RefreshScore();
    }

    public void QuitApplication()
	{
        Application.Quit();
	}

   

}
