using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusBar : MonoBehaviour
{
	public GameObject Bonusbar;
	public BonusList BonusList;
	public Image BonusPic;
    public RectTransform BonusTimeBar;
    public float BarLenghtMax;
	float CurrentBonusTime;
	float BonusDurtion;

	public void Start()
	{
		CurrentBonusTime = 1.0f;
	}
	
	public void Update()
	{
		SetBarLenght(CurrentBonusTime);
		CurrentBonusTime -= Time.deltaTime / BonusDurtion;
		if (CurrentBonusTime <= 0)
		{
			TurnOffUI();
		}
		
	}

	public void SetBonusPic(Sprite sprite)
	{
        BonusPic.sprite = sprite;
	}
    public void SetBarLenght(float ratio)
	{
		BonusTimeBar.anchorMax = new Vector2(ratio, BonusTimeBar.anchorMax.y);
	}

	public void TurnOffUI()
	{
		Bonusbar.SetActive(false);
	}

	public void TurnOnUI()
	{
		Bonusbar.SetActive(true);
	}

	public void InitBar(string Bonusname)
	{
		BonusData data = BonusList.GetBonusByName(Bonusname);
		SetBonusPic(data.ObjectPicture);
		BonusDurtion = data.Duration;
		CurrentBonusTime = 1.0f;
	}
}
