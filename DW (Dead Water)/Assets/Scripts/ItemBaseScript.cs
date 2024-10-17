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
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public enum StatToChange
    {
        None,
        attack,
        maxHp,
        healAmount
    };
}
