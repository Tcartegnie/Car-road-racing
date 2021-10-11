using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapLine : MonoBehaviour
{
	public float SwapDuration;
	public Transform[] LanePosition;
	public Transform ModelTransform;

	public AnimationCurve curve;


	public void SetLinePosition(int LaneID)
	{
		LaneID = Mathf.Clamp(LaneID, 0, 4);
		ModelTransform.position = GetLanePosition(LaneID);
	}

	public Vector3 GetLanePosition(int LaneID)
	{
		LaneID = Mathf.Clamp(LaneID, 0, LanePosition.Length-1);
		return LanePosition[LaneID].position;
	}

	public Vector3 GetRandomLanePosition()
	{
		return GetLanePosition(Random.Range(0,4));
	}

	public void GoOnRandomLine()
	{
		StartCoroutine(SwapToLine(GetRandomLanePosition()));
	}


	public void CallStopAllCoroutine()
	{
		StopAllCoroutines();
	}

    public IEnumerator SwapToLine(Vector3 Destination)
	{
		Vector3 originPos = ModelTransform.position;
		Vector3 destination = Destination;

		for (float i = 0; i < 1; i += Time.deltaTime / SwapDuration)
		{
			ModelTransform.position = Vector3.Lerp(new Vector3(originPos.x, ModelTransform.position.y, originPos.z), new Vector3(destination.x, ModelTransform.position.y, originPos.z), curve.Evaluate(i));
			yield return null;
		}
		ModelTransform.position = Vector3.Lerp(originPos, new Vector3(destination.x, ModelTransform.position.y, originPos.z), 1);
	}

	public IEnumerator SwapToLine(Vector3 Destination, float Duration)
	{
		Vector3 originPos = ModelTransform.position;
		Vector3 destination = Destination;

		for (float i = 0; i < 1; i += Time.deltaTime / Duration)
		{
			ModelTransform.position = Vector3.Lerp(new Vector3(originPos.x, ModelTransform.position.y, originPos.z), new Vector3(destination.x, ModelTransform.position.y, destination.z), curve.Evaluate(i));
			yield return null;
		}
		ModelTransform.position = Vector3.Lerp(originPos, new Vector3(destination.x, ModelTransform.position.y, destination.z), 1);
	}

	public IEnumerator SwapToLine(Vector3 Destination, Vector3 offset)
	{
		Vector3 originPos = ModelTransform.position;
		Vector3 destination = Destination;

		for (float i = 0; i < 1; i += Time.deltaTime / SwapDuration)
		{
			ModelTransform.position = Vector3.Lerp(new Vector3(originPos.x, ModelTransform.position.y, originPos.z), new Vector3(destination.x + offset.x, ModelTransform.position.y, destination.z + offset.z), curve.Evaluate(i));
			yield return null;
		}
		ModelTransform.position = Vector3.Lerp(originPos, new Vector3(destination.x + offset.x, ModelTransform.position.y, destination.z + offset.z), 1);
	}




	public IEnumerator SwapToLine(Vector3 Destination, Vector3 offset, float Duration)
	{
		Vector3 originPos = ModelTransform.position;
		Vector3 destination = Destination;

		for (float i = 0; i < 1; i += Time.deltaTime / Duration)
		{
			ModelTransform.position = Vector3.Lerp(new Vector3(originPos.x, ModelTransform.position.y, originPos.z), new Vector3(destination.x + offset.x, ModelTransform.position.y, destination.z + offset.z), curve.Evaluate(i));
			yield return null;
		}
		ModelTransform.position = Vector3.Lerp(originPos, new Vector3(destination.x + offset.x, ModelTransform.position.y, destination.z + offset.z), 1.0f);
	}

}
