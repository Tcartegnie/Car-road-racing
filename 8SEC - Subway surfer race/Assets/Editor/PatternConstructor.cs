using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;


/*
 1 - Ajouter la possiblilité de mettre différent trains (genre la rampe)
 2 - Ajouter un button pour feed la liste de pattern automatiquement.
 */



public class PatternConstructor : EditorWindow
{

	string FileName = "";

	static int RoadLenght = 5;

	public bool[] TrainSelected = new bool[RoadLenght];
	public TrainType[] trainType = new TrainType[RoadLenght];
	public bool[] coinsSelected = new bool[RoadLenght];

	

	SegementDifficulty difficulty;

	List<bool[]> TrainConfirmed = new List<bool[]>();
	List<TrainType[]> trainTypes = new List<TrainType[]>();

	string[] DifficultyName = new string[3] {"Easy","Normal","Hard"};

	[MenuItem("Tools/Pattern constructor")]
	static void Init()
	{
		PatternConstructor window = (PatternConstructor)GetWindow(typeof(PatternConstructor), true, "Patter constructor");
	
		window.Show();
	}

	private void OnGUI()
	{
		difficulty = (SegementDifficulty)EditorGUI.EnumPopup(new Rect(10, 10, 100, 10), difficulty);
		GUI.Label(new Rect(10,40,300,15),"Pattern name", EditorStyles.boldLabel);
		GUI.Label(new Rect(10,60,300,15),"Pattern Lenght", EditorStyles.boldLabel);


		FileName = GUI.TextArea(new Rect(120, 40, 300, 15),FileName); 
		GUI.Label(new Rect(10, 120, 100, 15), "Train", EditorStyles.boldLabel);
		GUI.Label(new Rect(10, 150, 110, 15), "Coin", EditorStyles.boldLabel);

	

		for(int i = 0; i < RoadLenght; i++)
		{
			GUI.Label(new Rect(45 + (20 * i),100,100, 10), (i+1).ToString(), EditorStyles.boldLabel);
			TrainSelected[i] = EditorGUI.Toggle(new Rect(45 + (20 * i) , 120, 10, 10), TrainSelected[i]);
			coinsSelected[i] = EditorGUI.Toggle(new Rect(45 +(20 * i) , 150, 10, 10), coinsSelected[i]);
			//trainType[i] = (TrainType)EditorGUI.EnumPopup(new Rect(60, 88 + (20 * i), 100, 10),trainType[i]);
		}
	
		if (GUI.Button(new Rect(10, 200, 200, 50), "Add Segement"))
			AddSegement(TrainSelected,trainType);


		if (GUI.Button(new Rect(10, 275, 200, 50), "Clear pattern"))
			ClearPattern();

		if (GUI.Button(new Rect(10, 350, 200, 50), "Creat build file"))
			CreatAssets();

		for (int i = 0; i < TrainConfirmed.Count; i++)
		{
			for (int j = 0; j < RoadLenght; j++)
			{
				GUI.Label(new Rect(220 + (20 * j), 100, 100, 10), (j + 1).ToString(), EditorStyles.boldLabel);
				EditorGUI.Toggle(new Rect(220 + (20 * j), 120 + (20 * i), 50, 10), TrainConfirmed[i][j]);
			}
		}


	}

	public void AddSegement(bool[] trains, TrainType[] Types)
	{
		bool[] values = new bool[RoadLenght];
		TrainType[] Type = new TrainType[RoadLenght];
		for(int i = 0; i <RoadLenght;i++)
		{
			values[i] = trains[i];
			Type[i] = Types[i];
		}
		TrainConfirmed.Add(values);
		trainTypes.Add(Type);
 	}

	public void ClearCurrentSegement()
	{
		for (int i = 0; i < TrainSelected.Length; i++)
		{
			TrainSelected[i] = false;
		}
	}

	public void ClearPattern()
	{
		TrainConfirmed.Clear();
	}

	public void CreatAssets()
	{
		RoadPattern pattern = CreateInstance<RoadPattern>();
		for (int i = 0; i < TrainConfirmed.Count; i++)
		{
			pattern.MakeSegment(difficulty,trainTypes[i],TrainConfirmed[i], new bool[0]);
		}
		AssetDatabase.CreateAsset(pattern, "Assets/ScriptableObject/Road/Pattern/"+DifficultyName[(int)difficulty] +"/"+ FileName +".asset");
		AssetDatabase.SaveAssets();
	}
}
