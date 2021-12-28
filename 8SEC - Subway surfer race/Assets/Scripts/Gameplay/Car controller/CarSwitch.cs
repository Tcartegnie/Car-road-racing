using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSwitch : MonoBehaviour
{
    [SerializeField]
    Transform CarTransform;
    [SerializeField]
    GameObject CurrentVehicule;
    [SerializeField]
    CarCinematiqueMovement tranistion;
    [SerializeField]
    CarStat carState;
    [SerializeField]
    CarSoundPlayer soundPlayer;
    [SerializeField]
    CarController carController;

    public void CallCarChangement(CarData data)
	{
        StartCoroutine(SwitchFromCar(data));
	}

    void InstanciateNewVehicule(CarData data)
	{
        GameObject GO = CurrentVehicule;
        CurrentVehicule = Instantiate(data.GameObject,CarTransform);
        SetCarSound(data);
        SetParticleEmmiter();
        Destroy(GO);
	}

    public void SetParticleEmmiter()
    {
        CarParticleEmmiter ParticleEmmiter = CurrentVehicule.GetComponent<CarParticleEmmiter>();
        carState.CarParticleEmmiter = ParticleEmmiter;
        carController.CarParticleEmmiter = ParticleEmmiter;
    }

    public void SetCarSound(CarData data)
	{
        CarSoundPlayer SoundPlayer = CurrentVehicule.GetComponent<CarSoundPlayer>();
        soundPlayer.list = data.Soundlist;
	}

    IEnumerator SwitchFromCar(CarData data)
	{
        yield return StartCoroutine(tranistion.CarTransitionOut());
        InstanciateNewVehicule(data);
        yield return StartCoroutine(tranistion.CarTransitionIn());
    }
}
