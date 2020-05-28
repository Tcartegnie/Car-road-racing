using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoostButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public PlayerInput Playerinput;
	public void OnPointerDown(PointerEventData eventData)
	{
		Playerinput.AccelerationEnable = true;
	}

	
	

	public void OnPointerUp(PointerEventData eventData)
	{
		Playerinput.AccelerationEnable = false;
	}

}
