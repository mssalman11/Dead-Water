using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Author: Leland LeVassar, with help from Night Run tutorial
//Date created: 10/7/24
//Purpose: To take in information about equipment and pass it on to the character stats

public class EquipmentSlotScript : MonoBehaviour, IPointerClickHandler
{
    //Slot appearance
    [SerializeField]
    private Image slotImage;

    [SerializeField]
    private Text slotName;

    [SerializeField]
    private Image playerDisplayImage;

    //Slot Data
    [SerializeField]
    private ItemType itemType = new ItemType();

    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;

    private InventoryManager inventoryManager;
    private EquipmentLibraryScript equipmentSOLibrary;

    private bool slotInUse;
    [SerializeField]
    public GameObject selectedShader;
    [SerializeField]
    public bool thisItemSelected;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        equipmentSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<EquipmentLibraryScript>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        if(thisItemSelected && slotInUse)
        {
            UnequipGear();
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }
    }

    //Equipping gear logic
    public void EquipGear(Sprite itemSprite, string itemName, string itemDescription)
    {
        //Logic for if something is already equipped
        //Sends it back to inventory and updates char stats window
        if (slotInUse)
        {
            UnequipGear();
        }

        //Update Image
        this.itemSprite = itemSprite;
        slotImage.sprite = this.itemSprite;
        slotName.enabled = false;

        //Update Item Data
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        //Update Display Image
        playerDisplayImage.sprite = itemSprite; 

        //Update Character Stats in equip menu
        for(int i = 0; i < equipmentSOLibrary.itemScriptableObject.Length; i++)
        {
            if(equipmentSOLibrary.itemScriptableObject[i].itemName == this.itemName)
            {
                equipmentSOLibrary.itemScriptableObject[i].EquipItem();
            }
        }

        slotInUse = true;
    }

    public void UnequipGear()
    {
        inventoryManager.DeselectAllSlots();

        //Sends item back to inventory with quantity of 1
        inventoryManager.AddItem(itemName, 1, itemSprite, itemDescription, itemType);

        //Update Slot Image
        slotName.enabled = true;
    }
}
