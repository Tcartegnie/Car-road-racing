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
    CarController carController;

    public void CallCarChangement(GameObject NewVehicule)
	{
        StartCoroutine(SwitchFromCar(NewVehicule));
	}

    void InstanciateNewVehicule(GameObject NewVehicule)
	{
        GameObject GO = CurrentVehicule;
        CurrentVehicule = Instantiate(NewVehicule,CarTransform);
        SetParticleEmmiter();
        Destroy(GO);
	}

    public void SetParticleEmmiter()
    {
        CarParticleEmmiter ParticleEmmiter = CurrentVehicule.GetComponent<CarParticleEmmiter>();
        carState.CarParticleEmmiter = ParticleEmmiter;
        carController.CarParticleEmmiter = ParticleEmmiter;
    }

    IEnumerator SwitchFromCar(GameObject NewVehicule)
	{
        yield return StartCoroutine(tranistion.CarTransitionOut());
        InstanciateNewVehicule(NewVehicule);
        yield return StartCoroutine(tranistion.CarTransitionIn());
    }
}
