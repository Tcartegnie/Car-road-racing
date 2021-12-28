using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CarData
{
    public Sprite CarPicture;
    public GameObject GameObject;
    public int Cost;
    public string name;
    public SoundList Soundlist;
}

[CreateAssetMenu(fileName = "Car list", menuName = "ScriptableObjects/Car/Car list", order = 1)]
public class CarList : ScriptableObject
{
    public List<CarData> datas = new List<CarData>();

    public GameObject GetObjectByName(string name)
	{
      return datas.Find(obj => obj.name == name).GameObject;
	}

    public List<GameObject> GetAllObjectUnder(int score)
	{
        List<GameObject> ObjectFounds = new List<GameObject>();
        foreach (CarData data in datas)
        {
            if (data.Cost <= score)
            {
                ObjectFounds.Add(data.GameObject);
            }
        }
        return ObjectFounds;
    }
}
