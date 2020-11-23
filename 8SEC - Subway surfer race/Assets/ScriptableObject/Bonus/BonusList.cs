using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BonusData
{
	public string Name;
	public int RandomRate;
	public int ID;
}

[CreateAssetMenu(fileName = "Bonus", menuName = "ScriptableObjects/BonusList", order = 1)]
public class BonusList : ScriptableObject
{
	public List<BonusData> Bonus;

	public BonusData GetBonusByID(int ID)
	{
		return Bonus.Find(BonusName => BonusName.ID == ID);
	}
	public BonusData GetBonusByName(string name)
	{
		return Bonus.Find(BonusName => BonusName.Name == name);
	}

	public BonusData GetRandomBonus()
	{
		return Bonus[Random.Range(0, Bonus.Count)];
	}
}
