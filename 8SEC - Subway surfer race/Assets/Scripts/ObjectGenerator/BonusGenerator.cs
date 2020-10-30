using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGenerator : ObjectGenerator
{
  public void GenerateBonus()
	{
		for (int i = 0; i < Spawns.Count ;i++)
		{
			GenerateObject("BonusHeart", i, new Vector3());
		}
	}
}
