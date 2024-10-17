using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Leland LeVassar with help from Night Run tutorial
//Created: 10/7/24
//Purpose: Managing data for items and equipment collected and passing it to the inventory slots

public enum ItemType
{
    none,
    attack,
    armor,
    wild
};

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject EquipmentMenu;
    private bool menuActivated;
    public InventorySlotScript[] itemSlot;
    public EquipmentSlotScript[] equipmentSlot;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void AddItem(string itemName, int quantity, Sprite itemImage, string itemDescription, ItemType itemType)
    {
        //Debug.Log("itemName = " + itemName + "quantity = " + quantity + "itemSprite " + itemSprite);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, itemImage, itemDescription, itemType);
                return;
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

}
