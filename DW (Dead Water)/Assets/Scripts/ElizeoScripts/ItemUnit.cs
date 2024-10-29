using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUnit : MonoBehaviour
{

    public ItemBaseScript itemStat;

    public string itemName;

    public float priority;
    public float healSpeed;
    public float healValue;

    public int itemHP;
    public int itemAttack;


    public void Start()
    {
        itemName = itemStat.name;
        itemAttack = itemStat.attack;
        priority = itemStat.attackSpeed;
        itemHP = itemStat.maxHp;
        setRarity(rarity);
    }

    public void setRarity(itemRarity rarity)
    {
        switch (rarity)
        {
            case itemRarity.COMMON:
                Debug.Log("This item is COMMON");
                break;

            case itemRarity.RARE:
                Debug.Log("This item is RARE");
                break;

            case itemRarity.SUPER_RARE:
                Debug.Log("This item is SUPER RARE");
                break;

            case itemRarity.ULTRA_RARE:
                Debug.Log("This item is ULTRA RARE");
                break;

        }
    }

    public enum itemRarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        SUPER_RARE,
        ULTRA_RARE
    }

    public itemRarity rarity;

}
