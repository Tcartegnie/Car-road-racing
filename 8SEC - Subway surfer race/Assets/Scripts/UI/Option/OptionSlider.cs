using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSlider : MonoBehaviour
{

    public Slider slider;
	public ISaveComponent SaveComponent;
	public string StringIDSaveSlider;
	public void Start()
	{
		
		SaveComponent = GetComponent<ISaveComponent>();
		SetSliderValue();
	}

	public void SetSliderValue()
	{
		slider.value = PlayerPrefs.GetFloat(StringIDSaveSlider);
	}
	public void OnValueChanged() 
	{
		SaveComponent.OnValuechanged(slider.value);
	}
}
