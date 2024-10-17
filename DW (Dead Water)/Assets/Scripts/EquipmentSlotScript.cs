using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Author: Leland LeVassar, with help from Night Run tutorial
//Date created: 10/7/24
//Purpose: To take in information about equipment and pass it on to the character stats

public class EquipmentSlotScript : MonoBehaviour
{
    //Slot appearance
    [SerializeField]
    private Image slotImage;

    [SerializeField]
    private Text slotName;

    //Slot Data
    [SerializeField]
    private ItemType itemType = new ItemType();

    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;

    private bool slotInUse;

    //Equipping gear logic
    public void EquipGear(Sprite itemSprite, string itemName, string itemDescription)
    {
        //Update Image
        this.itemSprite = itemSprite;
        slotImage.sprite = this.itemSprite;

        //Update Item Data
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        slotInUse = true;
    }
}
