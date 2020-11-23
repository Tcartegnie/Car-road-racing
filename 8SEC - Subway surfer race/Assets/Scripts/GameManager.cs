using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;
	public int life;
	public bool OnPause;
	public int Life { get => life; set => life = value; }


	public static GameManager Instance()
	{
		if (instance == null)
		{
			instance = new GameObject("GameManager").AddComponent<GameManager>();
			DontDestroyOnLoad(instance);
		}
		return instance;
	}

	void Awake()
	{
		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public void SetPause(bool onPause)
	{
		OnPause = onPause;
	}

}
