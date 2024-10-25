using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManagement : MonoBehaviour
{
    public static ResourceManagement Instance {  get; private set; }

    public bool nextMove;

    private int totalCoins;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }

    private void addCoins(int c)
    {
        totalCoins += c;
    }

    private void removeCoins(int c) 
    { 
        totalCoins -= c;
    }

    private int totalCoinNumber()
    {
        return totalCoins;
    }

    public void isBattleOver()
    {
        if (BattleSystem.isEnemyDead)
        {
            nextMove = true;
        }
    }
}
