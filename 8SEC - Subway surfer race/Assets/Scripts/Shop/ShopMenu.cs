using UnityEngine;
using System.Collections.Generic;

public class ShopMenu : MonoBehaviour
{
	public CarSwitch carSwitch;
	public CarList cars;
	public ScoreSaveData score;
	public ShopMenuUI shopMenuUI;
	public List<CarData> CurrentList = new List<CarData>();
	int CurrentCarIndex = 0;

	public void Start()
	{
		InitShop();
	}
	public void InitShop()
	{
		CurrentList = cars.datas;
		RefreshUI();
	}

	public CarData GetCurrentCarData()
	{
		return CurrentList[CurrentCarIndex];
	}

	public void CheckCarID()
	{
		if(CurrentCarIndex < 0)
		{
			CurrentCarIndex = CurrentList.Count -1;
		}
		if(CurrentCarIndex > CurrentList.Count-1)
		{
			CurrentCarIndex = 0;
		}
	}

	public void CheckCarPrice()
	{
		CarData cardata = GetCurrentCarData();
		int Score = score.GetCoinValue();

		if (score.IsCarAlreadyBuyed(cardata.name))
		{
			shopMenuUI.EnableBuyButton();
			shopMenuUI.UpdateBuyButtonTitle("SELECT");
		}
		else
		{
			if (Score >= cardata.Cost)
			{
				shopMenuUI.EnableBuyButton();
				shopMenuUI.UpdateBuyButtonTitle("BUY");
			}
			else
			{
				shopMenuUI.UpdateBuyButtonTitle("BUY");
				shopMenuUI.DisableBuyButton();
			}
		}
	}

	

	public void RefreshUI()
	{
		CarData data = GetCurrentCarData();
		shopMenuUI.SetCarPicture(data.CarPicture);
		shopMenuUI.SetCarValue(data.Cost);
		CheckCarPrice();
	}

    public void OnLeftButtonPressed()
	{
		CurrentCarIndex--;
		CheckCarID();
		RefreshUI();
	}

    public void OnRightButtonPressed()
	{
		CurrentCarIndex++;
		CheckCarID();
		RefreshUI();
	}

	

    public void OnBuyButtonPressed()
	{
		CarData data = GetCurrentCarData();
		if (score.IsCarAlreadyBuyed(data.name))
		{
			SelectCar();
		}
		else
		{
			BuyCar();
		}
	}

	public void SelectCar()
	{
		carSwitch.CallCarChangement(GetCurrentCarData().GameObject);
	}

	public void BuyCar()
	{
		CarData data = GetCurrentCarData();
		score.AddCoinCount(-data.Cost);
		score.AddOwnedCar(data.name);
		shopMenuUI.RefreshCoinDisplayer();
		RefreshUI();
	}

    public void OnReturnButtonPressed()
	{
		shopMenuUI.OnExitShopMenu();
	}
}
