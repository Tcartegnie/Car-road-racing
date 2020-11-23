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

	public void Update()
	{
		if(Input.touches.Length > 0)
		{
			if(Input.touches[0].phase == (TouchPhase.Began))
			{
				Debug.Log("Ecran is touched");
			}
			if (Input.touches[0].phase == (TouchPhase.Ended))
			{
				OnSliderRealese();
			}
		}
	}

	public void SetSliderValue()
	{
		slider.value = PlayerPrefs.GetFloat(StringIDSaveSlider);
	}
	public void OnValueChanged() 
	{
		SaveComponent.OnValuechanged(slider.value);
	}

	public void OnSliderRealese()
	{
		SaveComponent.OnSliderReleasde(slider.value);
	}
}
