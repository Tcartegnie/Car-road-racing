using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuUI : MonoBehaviour
{
	public GameObject MainMenu;
	public GameObject ShopMenu;
	public CoinCountDisplayer coins;
	public Button BuyButton;

	[SerializeField]
	Image CarPicture;
	[SerializeField]
	Text CarValue;

	public void TurnOffMenu()
	{
		ShopMenu.SetActive(false);
	}

	public void OnExitShopMenu()
	{
		TurnOffMenu();
		MainMenu.SetActive(true);
	}
	
	public void RefreshCoinDisplayer()
	{
		coins.UpdateScoreToDisplay();
	}

	public void SetCarPicture(Sprite picture)
	{
		CarPicture.sprite = picture;
	}

	public void SetCarValue(int value)
	{
		CarValue.text = value.ToString();
	}

	public void EnableBuyButton()
	{
		BuyButton.interactable = true;
	}
	public void DisableBuyButton()
	{
		BuyButton.interactable = false;
	}

	public void UpdateBuyButtonTitle(string title)
	{
		BuyButton.GetComponentInChildren<Text>().text = title;
	}

}
