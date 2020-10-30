using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BonusData
{
	public string Name;
	public int RandomRate;
}

[CreateAssetMenu(fileName = "Bonus", menuName = "ScriptableObjects/BonusList", order = 1)]
public class BonusList : ScriptableObject
{
	public List<BonusData> Bonus;

	public BonusData GetRandomBonus()
	{
		return Bonus[Random.Range(0, Bonus.Count)];
	}
}
