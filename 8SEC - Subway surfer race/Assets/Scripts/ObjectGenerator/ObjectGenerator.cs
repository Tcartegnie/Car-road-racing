using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
	
    protected List<GameObject> CurrentObjects = new List<GameObject>();
	public List<Transform> Spawns = new List<Transform>();


	public GameObject GenerateObject(string name, Vector3 position)
	{
		GameObject GO = ObjectPooler.instance.SpawnFromPool(name, position, new Quaternion());
		CurrentObjects.Add(GO);
		return GO;
	}

	public GameObject GenerateObject(string name, int SpawnID, Vector3 Offset)
	{
		Transform spawn = Spawns[SpawnID];
		GameObject GO = ObjectPooler.instance.SpawnFromPool(name, spawn.position + Offset, spawn.rotation);
		CurrentObjects.Add(GO);
		GO.transform.SetParent(spawn);
		return GO;
	}

	public GameObject GenerateObject(string name, int SpawnID)
	{
		Transform spawn = Spawns[SpawnID];
		GameObject GO = ObjectPooler.instance.SpawnFromPool(name, spawn.position, spawn.rotation);
		CurrentObjects.Add(GO);
		GO.transform.SetParent(spawn);
		return GO;
	}
	
	public Vector3 GetLanePositon(int SpawnID)
	{
		return Spawns[SpawnID].position;
	}

	public void RemoveObjects()
	{
		for(int i = 0; i < CurrentObjects.Count;i++)
		{
			RemoveObject(CurrentObjects[i]);
		}
		CurrentObjects.Clear();
	}

	public void RemoveObject(GameObject obj)
	{
		obj.SetActive(false);
		obj.transform.SetParent(null);
	}

}
