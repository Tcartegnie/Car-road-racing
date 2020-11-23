using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	public float PauseCoolDown;
	public GameObject PauseUI;
	public Text TextPause;
	bool IsOnPause;




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
		GameManager GM = GameManager.instance;
		GM.SetPause(true);
		PauseUI.gameObject.SetActive(true);
		TextPause.text = "Game on pause, touch the screen to resume.";
	
	}

	public void Resume()
	{
		GameManager GM = GameManager.instance;
		PauseUI.gameObject.SetActive(false);
		GM.SetPause(false);
	}

}
