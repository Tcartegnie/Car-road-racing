using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public AudioSource[] Musics;
    public AudioSource[] SFX;
	public string MusicSaveID;
	public string SFXSaveID;

	public void Awake()
	{
		SetMusicVolume();
		SetSFXVolume();
	}

	public void SaveSFXVolume(float volume)
	{
		PlayerPrefs.SetFloat(SFXSaveID,volume);
	}
	public void SaveMusicVolume(float volume)
	{
		PlayerPrefs.SetFloat(MusicSaveID, volume);
	}
    public void SetMusicVolume()
	{
		float value = GetVolumValue(MusicSaveID);
		for (int i = 0; i < Musics.Length; i++)
		{
			Musics[i].volume = value;
		}
	}

	public float GetVolumValue(string ValueID)
	{
		return PlayerPrefs.GetFloat(ValueID);
	}

	public void SetSFXVolume()
	{
		float value = GetVolumValue(SFXSaveID);
		for (int i = 0; i < SFX.Length; i++)
		{
			SFX[i].volume = value;
		}
	}
}
