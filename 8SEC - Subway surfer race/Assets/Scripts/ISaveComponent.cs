using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveComponent
{
	void OnValuechanged(float value);
	void OnSliderReleasde(float value);
}
