using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    EnemyBaseScript _base;
    int level;

    public EnemyClass(EnemyBaseScript mBase, int mLevel)
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
}
