using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct ObjectsPattern
{
	public GameObject Object;
	public int LineID;
	public int NumberofObjects;
	public float Cooldown;
	public float Spacement;
}


[CreateAssetMenu(fileName = "CoinPatternList", menuName = "ScriptableObjects/CoinPattern ", order = 1)]
public class ObjectsPaterns : ScriptableObject
{
	public List<ObjectsPattern> CoinsPatterns = new List<ObjectsPattern>();
}
