using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	public float PauseCoolDown;
	public GameObject PauseUI;
	public Text TextPause;
	GameManager GM;
	bool IsOnPause;


	public void Start()
	{
		GM = GameManager.instance;
	}

	private void OnApplicationPause(bool pause)
	{
		if (pause)
		{
			Pause();
			//IsOnPause = true;

		}
		else
		{
			Resume();
		}
	}

	private void OnApplicationFocus(bool focus)
	{
		if(!focus)
		{
			Pause();
			//IsOnPause = true;
		
		}
		else
		{
			Resume();
		}
	}

	public void Update()
	{
		if(Input.touchCount > 0 && IsOnPause)
		{
			Resume();
			
		}
	}

	public void Pause()
	{
		GM.OnPause = true;
		PauseUI.gameObject.SetActive(true);
		TextPause.text = "Game on pause, touch the screen to resume.";
	
	}

	public void Resume()
	{
		PauseUI.gameObject.SetActive(false);
		GM.OnPause = false;
	}

}
