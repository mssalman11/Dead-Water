using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: LeVassar, Leland
//Created: 10/7/24
//Purpose: Controls item's equip regions and stats. 

//Slot Tags (obsolete)
//public enum slotTag { Default, Attack, Armor, Wild}

public class ItemScript : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    [TextArea]
    [SerializeField]
    private string itemDescription;

    private InventoryManager inventoryManager;

    public ItemType itemType;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void GiveItem()
    {
        inventoryManager.AddItem(itemName, quantity, sprite, itemDescription, itemType);
    }
}
