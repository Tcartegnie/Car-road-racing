using UnityEngine;

public class BuildingGenerator : ObjectGenerator
{
   public BuildingList Buildings;


	public void GenerateBuilding()
	{
		BuildingPattern pattern = Buildings.GetRandomList();
		for (int i = 0; i < Spawns.Count; i++)
		{
			GenerateObject(pattern.Pattern[i],i,new Vector3());
		}
	}

}
