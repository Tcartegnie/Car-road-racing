using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSaveMusic : MonoBehaviour, ISaveComponent
{

	
	public SoundHandler soundHandler;

	public void Start()
	{
		SetMusicVolume();	
	}


	public void OnSliderReleasde(float value){}

	public void OnValuechanged(float value)
	{
		SaveMusicVolume(value);
		SetMusicVolume();
	}

	public void SetMusicVolume()
	{
		soundHandler.SetMusicVolume();
	}
	public void SaveMusicVolume(float volume)
	{
		soundHandler.SaveMusicVolume(volume);
	}

	
	
}
