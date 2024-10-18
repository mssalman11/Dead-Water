using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Leland LeVassar
//Created: 10/15/24
//Purpse: To create a base template for all items in the game
[CreateAssetMenu(fileName = "NewItem ", menuName = "NewItem/Create new Item")]

public class ItemBaseScript : ScriptableObject
{
    public string itemName;

    //Stat variables
    public float attack, attackSpeed, maxHp, healAmount, healRate;

    public void EquipItem()
    {
        //Update stats
        StatManagerScript statManager = GameObject.Find("StatManager").GetComponent<StatManagerScript>();
        statManager.attack += attack;
        //When updating rates always remember, - faster and + is slower
        statManager.attackSpeed += attackSpeed;
        statManager.maxHp += maxHp;
        statManager.healAmount += healAmount;
        //When updating rates always remember, - faster and + is slower
        statManager.healRate += healRate;
    }

    /*
    public void UnequipItem()
    {
        //Update stats
        PlayerStats playerstats = GameObject.Find("StatManager").GetComponent<StatManagerScript>();
        statManager.attack -= attack;
        statManager.attackSpeed -= attackSpeed;
        statManager.maxHp -= maxHp;
        statManager.healAmount -= healAmount;
        statManager.healRate -= healRate;
    }
    */
}
