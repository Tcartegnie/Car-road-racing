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
	public bool[] BonusSpawned = new bool[RoadLenght];

	int ToogleOffset = 40;

	SegementDifficulty difficulty;

	List<bool[]> TrainConfirmed = new List<bool[]>();
	List<bool[]> CoinsConfirmed = new List<bool[]>();
	List<bool[]> BonusConfirmed = new List<bool[]>();
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
		GUI.Label(new Rect(10, 140, 100, 15), "Train", EditorStyles.boldLabel);
		GUI.Label(new Rect(10, 190, 110, 15), "Coin", EditorStyles.boldLabel);
		GUI.Label(new Rect(10, 210, 110, 15), "Bonus", EditorStyles.boldLabel);


	
		for (int i = 0; i < RoadLenght; i++)
		{
			GUI.Label(new Rect(45 + (ToogleOffset * i),120,100, 10), (i+1).ToString(), EditorStyles.boldLabel);
			trainType[i] = (TrainType)EditorGUI.EnumPopup(new Rect(45 + ((ToogleOffset + 60) * i), 160, 60, 10), trainType[i]);
			TrainSelected[i] = EditorGUI.Toggle(new Rect(50 + (ToogleOffset * i) , 140, 10, 10), TrainSelected[i]);
			coinsSelected[i] = EditorGUI.Toggle(new Rect(50 +(ToogleOffset * i) , 190, 10, 10), coinsSelected[i]);
			BonusSpawned[i] = EditorGUI.Toggle(new Rect(50 +(ToogleOffset * i) , 210, 20, 20), BonusSpawned[i]);
			//trainType[i] = (TrainType)EditorGUI.EnumPopup(new Rect(60, 88 + (20 * i), 100, 10),trainType[i]);
		}
	
		if (GUI.Button(new Rect(10, 240, 200, 50), "Add Segement"))
			AddSegement(TrainSelected,trainType,coinsSelected,BonusSpawned);


		if (GUI.Button(new Rect(10, 315, 200, 50), "Clear pattern"))
			ClearPattern();

		if (GUI.Button(new Rect(10, 375, 200, 50), "Creat build file"))
			CreatAssets();

		for (int i = 0; i < TrainConfirmed.Count; i++)
		{
			for (int j = 0; j < RoadLenght; j++)
			{
				GUI.Label(new Rect(620 + (20 * j), 100, 100, 10), (j + 1).ToString(), EditorStyles.boldLabel);
				EditorGUI.Toggle(new Rect(620 + (20 * j), 120 + (20 * i), 50, 10), TrainConfirmed[i][j]);
			}
		}


	}

	public void AddSegement(bool[] trains, TrainType[] Types,bool[] CoinsValues,bool [] bonus)
	{
		bool[] TrainsConfirmed = new bool[RoadLenght];
		TrainType[] TypeConfirmed = new TrainType[RoadLenght];
		bool[] CoinValueConfirmed = new bool[RoadLenght];
		bool[] BonusConfirmed = new bool[RoadLenght];

		for(int i = 0; i <RoadLenght;i++)
		{
			TrainsConfirmed[i] = trains[i];
			TypeConfirmed[i] = Types[i];
			CoinValueConfirmed[i] = CoinsValues[i];
			BonusConfirmed[i] = bonus[i];
		}

		TrainConfirmed.Add(TrainsConfirmed);
		trainTypes.Add(TypeConfirmed);
		CoinsConfirmed.Add(CoinValueConfirmed);
		this.BonusConfirmed.Add(BonusConfirmed);
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
			pattern.MakeSegment(difficulty,trainTypes[i],TrainConfirmed[i], CoinsConfirmed[i], BonusConfirmed[i]);
		}
		AssetDatabase.CreateAsset(pattern, "Assets/ScriptableObject/Road/Pattern/"+DifficultyName[(int)difficulty] +"/"+ FileName +".asset");
		AssetDatabase.SaveAssets();
	}
}
