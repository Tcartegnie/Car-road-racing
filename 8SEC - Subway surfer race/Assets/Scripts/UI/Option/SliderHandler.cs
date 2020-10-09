using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderHandler : MonoBehaviour
{
	public bool SliderOnTouch;
	public void Update()
	{
		if(Input.touches.Length != 0)
		{
			SliderOnTouch = true;
			Debug.Log("Touch the slider");
		}

		if(Input.touches.Length == 0 && SliderOnTouch)
		{
			Debug.Log("Releas the slider");
		}
	}
}
