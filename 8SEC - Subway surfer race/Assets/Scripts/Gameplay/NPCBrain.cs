using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBrain : MonoBehaviour
{
	public float LenghtRoad;
	public List<CarController> Npcs = new List<CarController>();
    // Start is called before the first frame update
    void Start()
    {
		for(int i = 0; i < 5; i++)
		{
			Npcs[i].LaneID = i;
			Npcs[i].ZLandmarkPosition = transform.position.z;
			Npcs[i].transform.position = new Vector3(Npcs[i].transform.position.x, Npcs[i].transform.position.y, Random.Range(-LenghtRoad, LenghtRoad));
		}
  
    }

}
