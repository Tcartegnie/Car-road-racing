using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum bonus
{
    Invulnerability,
    BonusMultiplicator
}
public class BonusCaller : MonoBehaviour
{
    public Invulnerability invulnerabilty;
    public BonusMultiplicator bonusmultiplicator;

    //public BonusCalle invulnerabilty;

    public void CallMultiplicator(int multiplicator,float duration)
	{
        bonusmultiplicator.CallBonus(multiplicator,duration);
    }

    public void CallInvulnerability(float duration)
	{
        invulnerabilty.CallBonus(duration);
    }
    

}
