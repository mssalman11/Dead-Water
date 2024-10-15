using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public InventorySlotScript[] itemSlot;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void AddItem(string itemName, int quantity, Sprite itemImage, string itemDescription)
    {
        //Debug.Log("itemName = " + itemName + "quantity = " + quantity + "itemSprite " + itemSprite);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, itemImage, itemDescription);
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
