using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainGenerator : ObjectGenerator
{
	public void GenerateTrainSegement(RoadSegements segement)
	{
		for (int i = 0; i < segement.Spawns.Length; i++)
		{
			if(segement.Spawns[i])
			{
				GenerateObject(segement.name[i],i) ;
			}
		}
	}
}
