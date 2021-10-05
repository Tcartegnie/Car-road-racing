using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapLine : MonoBehaviour
{
	public float SwapDuration;
	public Transform[] LanePosition;
	public Transform CarTransform;

	public AnimationCurve curve;


	public void SetLinePosition(int LaneID)
	{
		LaneID = Mathf.Clamp(LaneID, 0, 4);
		CarTransform.position = GetLanePosition(LaneID);
	}

	public Vector3 GetLanePosition(int LaneID)
	{
		LaneID = Mathf.Clamp(LaneID, 0, LanePosition.Length-1);
		return LanePosition[LaneID].position;
	}

	public void GoOnRandomLine()
	{
		StartCoroutine(SwapToLine(Random.Range(0,4)));
	}


    public IEnumerator SwapToLine(int LaneID)
	{
		Vector3 OriginPos = CarTransform.position;
		Vector3 Destination = GetLanePosition(LaneID);

		for (float i = 0; i < 1; i += Time.deltaTime / SwapDuration)
		{
			CarTransform.position = Vector3.Lerp(new Vector3(OriginPos.x, CarTransform.position.y, OriginPos.z), new Vector3(Destination.x, CarTransform.position.y, OriginPos.z), curve.Evaluate(i));
			yield return null;
		}
		CarTransform.position = Vector3.Lerp(OriginPos, new Vector3(Destination.x, CarTransform.position.y, OriginPos.z), 1);
	}
}
