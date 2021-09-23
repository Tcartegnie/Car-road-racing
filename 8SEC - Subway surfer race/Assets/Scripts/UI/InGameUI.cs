using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InGameUI : MonoBehaviour
{
	public RectTransform ScoreRect;
	public RectTransform HeartRect;
	public RectTransform QuitButtonRect;
	public FloorSpawner floorSpawner;
	public CarStat CarStat;
	public PlayableDirector PlayReturnToMenu;
	public AudioSource InGameMusic;
	public Score score;
	GameManager GM;
	private void Start()
	{
		GM = GameManager.instance;
	}

	public void TurnOnUI()
	{
		ScoreRect.gameObject.SetActive(true);
		HeartRect.gameObject.SetActive(true);
		QuitButtonRect.gameObject.SetActive(true);
	}

	public void TurnOffUI()
	{
		ScoreRect.gameObject.SetActive(false);
		HeartRect.gameObject.SetActive(false);
		QuitButtonRect.gameObject.SetActive(false);
	}

	public void OnButtonReturnPressed()
	{
		GM.SetPause(true);
		TurnOffUI();
		floorSpawner.RestAndStopRoad();
		CarStat.InitCar();
		PlayReturnToMenu.Play();
		InGameMusic.Stop();
	}
}
