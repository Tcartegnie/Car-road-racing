using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SoundListData
{
    public AudioClip EngineSound;
    public AudioClip StraffSound;
    public AudioClip AirStraffSound;
    public AudioClip JumpSound;
}

[CreateAssetMenu(fileName = "Car sound list", menuName = "ScriptableObjects/Car/Sound list", order = 1)]
public class SoundList : ScriptableObject
{
    public SoundListData datas;
    public AudioClip GetEngineSound()
    {
        return datas.EngineSound;
    }

    public AudioClip GetStraffSound()
    {
        return datas.StraffSound;
    }

    public AudioClip GetAirStraffSound()
    {
        return datas.AirStraffSound;
    }

    public AudioClip GetJumpSound()
    {
        return datas.JumpSound;
    }

}
