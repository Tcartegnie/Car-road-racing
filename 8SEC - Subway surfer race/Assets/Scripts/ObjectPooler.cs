using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
	[System.Serializable]
	public class pool
	{
		public string poolName;
		public int Size;
	}

	[System.Serializable]
	public class poolObject : pool
	{
	
		public GameObject prefab;

	}




//	public List<pool> PoolList;
	public List<poolObject> PoolObject = new List<poolObject>();
	Dictionary<string, Queue<GameObject>> poolDictionnary;



	// Start is called before the first frame update

	#region Singelton
	public	static ObjectPooler instance;

	public void Awake()
	{
		instance = this;
	}
	#endregion
	void Start()
    {
		InitPoolObject();
		
	}


	public void InitPoolObject()
	{
		poolDictionnary = new Dictionary<string, Queue<GameObject>>();

		foreach (poolObject pool in PoolObject)
		{
			Queue<GameObject> ObjectPool = new Queue<GameObject>();
			for (int i = 0; i < pool.Size; i++)
			{
				GameObject obj = Instantiate(pool.prefab);
				obj.SetActive(false);
				ObjectPool.Enqueue(obj);
			}

			poolDictionnary.Add(pool.poolName, ObjectPool);
		}
	}



	public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion quaternion)
	{

		if (!poolDictionnary.ContainsKey(tag))
		{
			Debug.LogWarning("the pool " + tag + "Doesn't excist.");
			return null;
		}
		GameObject ObjecToSpawn = poolDictionnary[tag].Dequeue();
	
		ObjecToSpawn.SetActive(true);
		ObjecToSpawn.transform.position = position;
		ObjecToSpawn.transform.rotation = quaternion;
		


		poolDictionnary[tag].Enqueue(ObjecToSpawn);

		return ObjecToSpawn;
	}

}
