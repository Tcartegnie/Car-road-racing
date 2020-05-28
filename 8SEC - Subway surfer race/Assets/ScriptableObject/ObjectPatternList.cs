using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinPatternList", menuName = "ScriptableObjects/CoinPatternList", order = 1)]
public class ObjectPatternList : ScriptableObject
{
	public List<ObjectsPaterns> CoinsPatterns = new List<ObjectsPaterns>();
}
