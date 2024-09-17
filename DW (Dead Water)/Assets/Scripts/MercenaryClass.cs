using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Leland LeVassar
 * Created 09/16/24
 * Purpose: To be a base class for all Mercanaries to store base stats. 
 */

public class MercenaryClass
{
    CharactersBaseScript _base;
    int level;

    public MercenaryClass(CharactersBaseScript mBase, int mLevel)
    {
        _base = mBase;
        level = mLevel;
    }

    public int Attack
    {
        //temp math. will be changed later
        get { return Mathf.FloorToInt((_base.Attack * level) / 100f) + 1; }
    }

    public int MaxHealth
    {
        //temp math. will be changed later
        get { return Mathf.FloorToInt((_base.MaxHp * level) / 100f) + 2; }
    }

    public int HealAmount
    {
        //temp math. will be changed later
        get { return Mathf.FloorToInt((_base.HealAmount * level) / 100f) + 1; }
    }
}
