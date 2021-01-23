using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
	public GameObject UIGameOverRect;
	public GameOver gameOver;

	GameManager GM;

	public Text LifeQuantity;
	public Text LifeCost;

	public Button ContinueButton;

	

	public void Awake()
	{
		GM = GameManager.instance;
	}


	public void EnableUIGameOver()
	{
		UIGameOverRect.SetActive(true);
		RefreshUI();
	}

	public void DiseableGameOverUI()
	{
		UIGameOverRect.SetActive(false);
	}

	public void RefreshUI()
	{
		if(gameOver.IsEnoughtLife())
		{ 
			ContinueButton.interactable = true;
		}
		else
		{
			ContinueButton.interactable = false;
		}

		DisplayLifeCost();
		DisplayLifeCount();
	}


	public void DisplayLifeCost()
	{
		LifeCost.text = ": x" + gameOver.ResCost;
	}

	public void DisplayLifeCount()
	{
		LifeQuantity.text = ": x" + GM.life;
	}

}
