using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwapBar : MonoBehaviour
{
	public CarStat PlayerStat;
	public PlayerInput Playerinput;
	Vector2 startTouchPosition, endTouchPosition,SwipeDelta;
	bool TouchRealeas, tap, swipeLeft, SwipeRight,SwipeUp,SwipeDown;

	public float DeadZone = 100;

	public void Update()
	{

		if (!PlayerStat.IsDead && !GameManager.instance.OnPause)
		{

			tap = swipeLeft = SwipeRight = SwipeDown = SwipeUp = false;

			if (Input.touches.Length != 0)
			{
				if (Input.touches[0].phase == TouchPhase.Began)
				{
					tap = true;
					startTouchPosition = Input.mousePosition;
				}

				if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
				{
					startTouchPosition = SwipeDelta = Vector2.zero;
				}
			}

			SwipeDelta = Vector2.zero;
			if (startTouchPosition != Vector2.zero)
			{
				if (Input.touches.Length != 0)
				{
					SwipeDelta = Input.touches[0].position - startTouchPosition;
				}

				else if (Input.GetMouseButtonDown(0))
				{
					SwipeDelta = (Vector2)Input.mousePosition - startTouchPosition;
				}
			}

		

			if (SwipeDelta.magnitude > DeadZone)
			{

				float x = SwipeDelta.x;
				float y = SwipeDelta.y;


				if (Mathf.Abs(x) > Mathf.Abs(y))
				{
					x = Mathf.Clamp(x, -1, 1);
					Playerinput.Swipe(x);
				}
				else if (y > 0)
				{
					Playerinput.CallJump();
				}


				Debug.Log(new Vector2(x, y));
				Debug.Log((SwipeDelta));
				startTouchPosition = SwipeDelta = Vector2.zero;

			}
		}
		//if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		//	startTouchPosition = Input.GetTouch(0).position;

		//if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) && TouchRealeas)
		//{
		//	endTouchPosition = Input.GetTouch(0).position;

		//	Playerinput.Swipe(startTouchPosition, endTouchPosition);
		//	TouchRealeas = false;
		//}


		//if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
		//{
		//	TouchRealeas = true;
		//}
	}
}
