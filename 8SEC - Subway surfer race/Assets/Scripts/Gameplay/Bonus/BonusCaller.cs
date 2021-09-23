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
	public BonusList list;
	//public BonusCalle invulnerabilty;
	BonusData GetBonusByName(string BonusName)
	{
		return list.GetBonusByName(BonusName);
	}


    public void CallMultiplicator(int multiplicator,string BonusName)
	{
		BonusData data = GetBonusByName(BonusName);
		bonusmultiplicator.CallBonus(multiplicator, data.Duration);
    }

    public void CallInvulnerability(string BonusName)
	{
		BonusData data = GetBonusByName(BonusName);
        invulnerabilty.CallBonus(data.Duration);
    }
    

}
