using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BonusData
{
	public Sprite ObjectPicture;
	public string Name;
	public float Duration;
	public int RandomRate;
}


[CreateAssetMenu(fileName = "Bonus", menuName = "ScriptableObjects/BonusList", order = 1)]
public class BonusList : ScriptableObject
{
	public List<BonusData> Bonus;
	public BonusData GetBonusByName(string name)
	{
		return Bonus.Find(BonusName => BonusName.Name == name);
	}

	public BonusData GetRandomBonus()
	{
		return Bonus[Random.Range(0, Bonus.Count)];
	}
}
