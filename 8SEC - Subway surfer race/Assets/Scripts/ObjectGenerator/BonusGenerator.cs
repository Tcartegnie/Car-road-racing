using System;
using UnityEngine;

public class BonusGenerator : ObjectGenerator
{

	public BonusList bonus;


	public void SetBonusList(BonusList bonusList)
	{ 
		bonus = bonusList;
	}

  public void GenerateBonus(RoadSegements segement)
	{
		for (int i = 0; i < segement.Train.Length;i++)
		{
			if (segement.Bonus[i])
			{
				BonusData data = bonus.GetRandomBonus();
				if (UnityEngine.Random.Range(0, data.RandomRate) == 0)
				{
					GenerateObject(data.Name, i, new Vector3());
				}
			}
		}
	}
}
