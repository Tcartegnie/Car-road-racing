using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



[Serializable]
public class SaveCarData
{
    public List<string> datas = new List<string>();
   
    public void SaveCars(List<string> carValues)
	{
        datas = carValues;
	}

}

[Serializable]
public class SaveScoreData
{
    int score;
    public void SetNewScore(int score)
	{
        this.score = score;
    }

    public int GetHightScore()
	{
        return score;
	}
}

[Serializable]
public class SaveCoinData
{
    int CoinCount;
    public void AddCoinCount(int count)
	{
        CoinCount += count;
	}

    public void SetCoinCount(int count)
    {
        CoinCount = count;
    }

    public int GetCointCount()
	{
        return CoinCount;
	}
}
    
public class ScoreSaveData : MonoBehaviour
{

    public SaveScoreData ScoresData = new SaveScoreData();
    public SaveCoinData CoinsData = new SaveCoinData();
    public SaveCarData CarsData = new SaveCarData();
    public List<string> Cars = new List<string>();
    string DataPath;
    static string SaveScoreFileName = "/Score.dat";
    static string SaveCoinFileName = "/CoinCount.dat";
    static string SaveCarFileName = "/CarOwned.dat";
	public void Awake()
	{
        
        DataPath = Application.persistentDataPath;
       
        LoadPlayerScoreData();
        LoadCoinData();
        LoadCars();
        
	}

    void LoadCars()
	{
        if (IsExistingFile(SaveCarFileName))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = GetFileStream(SaveCarFileName, FileMode.Open);
            CarsData = formatter.Deserialize(stream) as SaveCarData;
            Cars = CarsData.datas;
            stream.Close();
        }
    }

    void SaveCarsData()
	{
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = GetFileStream(SaveCarFileName, FileMode.Create);
        CarsData.SaveCars(Cars);
        formatter.Serialize(stream, CarsData);
        stream.Close();
    }

    void SaveCoinData()
	{
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = GetFileStream(SaveCoinFileName,FileMode.Create);
        formatter.Serialize(stream, CoinsData);
        stream.Close();
    }

    void LoadCoinData()
	{
        if (IsExistingFile(SaveScoreFileName))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = GetFileStream(SaveCoinFileName, FileMode.Open);
            CoinsData = formatter.Deserialize(stream) as SaveCoinData;
            stream.Close();
        }
    }

	void SavePlayerScoreData()
	{
       BinaryFormatter formatter = new BinaryFormatter();
       FileStream stream = GetFileStream(SaveScoreFileName,FileMode.Create);
       formatter.Serialize(stream, ScoresData);
       stream.Close();
	}

    void LoadPlayerScoreData()
	{
        if (IsExistingFile(SaveScoreFileName))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = GetFileStream(SaveScoreFileName, FileMode.Open);
            ScoresData = formatter.Deserialize(stream) as SaveScoreData;
            stream.Close();
        }
    }

    public FileStream GetFileStream(string FileName, FileMode Mode)
	{
       FileStream stream = new FileStream(DataPath + FileName, Mode);
       return stream;   
    }


    public bool IsExistingFile(string FileName)
	{

        if (File.Exists(DataPath + FileName))
        {
            return true;
        }
        else
		{
            new ArgumentException("The file : " + FileName + " do not exist or cannot be found");
            return false;
		}
    }

   public bool CheckHightScore(int score)
	{
        LoadPlayerScoreData();
        int CurrentHightScore = GetHigtScore();
        if (score > CurrentHightScore)
        {
            return true;
        }
        return false;
    }

    public int GetHigtScore()
	{
        if (ScoresData != null)
        {
            return ScoresData.GetHightScore();
        }
        return 0;
	}


    public int GetCoinValue()
	{
        LoadCoinData();
        if (CoinsData != null)
        {
            return CoinsData.GetCointCount();
        }
        return 0;
    }

    public void SaveHightScore(int score)
	{
        if (CheckHightScore(score))
        {
            ScoresData.SetNewScore(score);
            SavePlayerScoreData();
        }
	}

    public void AddCoinCount(int Value)
	{
        CoinsData.AddCoinCount(Value);
        SaveCoinData();
	}

    public void SetCoin(int value)
	{
        CoinsData.SetCoinCount(value);
        SaveCoinData();
    }

    public void AddOwnedCar(string carName)
	{
       Cars.Add(carName);
       SaveCarsData();
	}

    public bool IsCarAlreadyBuyed(string carName)
	{
       return Cars.Exists(car => car == carName);
    }

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.O))
		{
            AddCoinCount(300);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetCoin(0);
        }
    }
}
