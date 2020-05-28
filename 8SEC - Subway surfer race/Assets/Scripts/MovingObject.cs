using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
	public float speed;
	public GameManager GM;
	// Update is called once per frame
	private void Start()
	{
		GM = GameManager.instance;
	}


	void Update()
    {
		if (!GM.OnPause)
		{
			MoveForward();
		}
    }

	public void MoveForward()
	{
		transform.position -= transform.forward * (Time.deltaTime * speed);
	}

}
