using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternEditor : MonoBehaviour
{
    Camera camera;
    Vector3 AnchorPosition = new Vector3();
    public Transform RoadSpawnOffset;
    public int CurrentSegementID;
    public float SegementTransitionSpeed;
    float CurrentIDProgress;

    public GameObject GhostTrain;

    public FloorSpawner floorSpawner;
    public List<GameObject> Segements = new List<GameObject>();
    public List<RoadSegements> Roadsegements = new List<RoadSegements>();
    public List<SegmentRoadEditor> RoadSegementsEditor = new List<SegmentRoadEditor>();
    RoadPattern pattern;
    public LayerMask mask;


    public float RoadSpeed;
    public AnimationCurve TransitionCurve;

    public bool OnTransition;
    public void Start()
    {
        AnchorPosition = RoadSpawnOffset.position;
        pattern = new RoadPattern();
        camera = Camera.main;
    }

    public void RemoveSegement()
    {
        ClampSegementID();

        GameObject GO = Segements[CurrentSegementID];
        RoadSegements seg = Roadsegements[CurrentSegementID];

        DestroySegement(GO);

        Roadsegements.Remove(seg);

        ClampSegementID();
    }

    private void DestroySegement(GameObject GO)
    {
        
        DestroyTrainOnSegement();
        Segements.Remove(GO);
        Destroy(GO);
    }

    private void DestroyTrainOnSegement()
	{
        for (int i = 0; i < 5; i++)
        {
            RemoveTrain(i);
        }
	}

    public void AddSegement()
    {
        Transform tr = RoadSpawnOffset;

        if (Segements.Count != 0)
        {
            tr = Segements[Segements.Count - 1].transform;
        }
        else
		{
            CurrentSegementID = 0;
		}

        GameObject GO = floorSpawner.SpawnNewSegement(tr.position + (tr.forward * floorSpawner.RoadDistance));
        Segements.Add(GO);
        Roadsegements.Add(new RoadSegements());

        GO.transform.SetParent(RoadSpawnOffset);
    }



    public void Update()
    {
       if (Input.GetMouseButtonUp(0))
       {
            CursorEditor();
       }
    }


    public void MoveLane()
	{
        StartCoroutine(MoveObject(RoadSpawnOffset,AnchorPosition - (floorSpawner.RoadDistance * (RoadSpawnOffset.forward * CurrentSegementID))));
	}

    public void SpawnSegement(int CurrentRoadSegementID)
    {
        Road road = Segements[CurrentSegementID].GetComponent<Road>();
        road.GenerateTrain(CurrentRoadSegementID);
    }

    public void CursorEditor()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);


        if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity,mask.value))
        {
            if (hit.transform.GetComponent<SegmentRoadEditor>() != null)
            {
                SegmentRoadEditor segEditor = hit.transform.GetComponent<SegmentRoadEditor>();
                OnClickOnSegement(segEditor.ID);
            }
        }
    }

    public void OnClickOnSegement(int LaneID)
	{
        if(!GetTrainState(LaneID))
		{
            AddTrain(LaneID);
		}
        else
		{
            RemoveTrain(LaneID);
		}
	}

    public bool GetTrainState(int LaneID)
	{
        return Roadsegements[CurrentSegementID].Train[LaneID];
    }
    
    public void RemoveTrain(int LaneID)
	{
       GetCurrentRoad().RemoveTrain(LaneID);
       Roadsegements[CurrentSegementID].Train[LaneID] = false;
    }

    public void OnSaveButtonPressed()
    {
        foreach (RoadSegements seg in Roadsegements)
        {
            pattern.AddSegements(seg);
        }
        pattern.SaveSegement();
    }

	private Road GetCurrentRoad()
	{
		return Segements[CurrentSegementID].GetComponent<Road>();
	}

    public void AddTrain(int SegementID)
	{
       Road road = GetCurrentRoad();
       road.GenerateTrain(SegementID);
       Roadsegements[CurrentSegementID].Train[SegementID] = true;
    }

	private void ClampSegementID()
    {
        CurrentSegementID = Mathf.Clamp(CurrentSegementID, 0, Segements.Count - 1);
    }

    public void OnNewPatternButtonPressed()
    {

    }

    public void OnLoadPatternButtonPressed()
    {

    }

    public void OnOptionButtonPressed()
    {

    }


    public void OnUpArrowPressed()
    {
        if (!OnTransition && Segements.Count > 0)
        {
            CurrentSegementID++;
            ClampSegementID();
            MoveLane();
        }
    }

     public void OnDownArrowPressed()
	{
        if (!OnTransition && Segements.Count > 0)
        {
            CurrentSegementID--;
            ClampSegementID();
            MoveLane();
        }
    }

    public void OnAddSegementButtonPressed()
	{
        AddSegement();
	}

    public void OnRemoveSegementButtonPressed()
    {
        RemoveSegement();
    }

  public IEnumerator MoveObject(Transform ObjectToMove, Vector3 Arrival)
	{
        OnTransition = true;
        Vector3 depart = ObjectToMove.position;
      
        for (float i  = 0; i < 1; i += Time.deltaTime / RoadSpeed)
		{
            ObjectToMove.position = Vector3.Lerp(depart, Arrival, TransitionCurve.Evaluate(i));
            yield return null;
		}
        ObjectToMove.position = Vector3.Lerp(depart, Arrival, TransitionCurve.Evaluate(1.0f));
        OnTransition = false;
    }

}
