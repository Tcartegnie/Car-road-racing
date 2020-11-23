using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainGenerator : ObjectGenerator
{
	public void GenerateTrainSegement(RoadSegements segement)
	{
		for (int i = 0; i < segement.Train.Length; i++)
		{
			if(segement.Train[i])
			{
				GenerateObject(segement.name[i],i);
			}
		}
	}
}
