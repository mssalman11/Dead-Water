using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Author: Leland LeVassar, with help from Night Run tutorial
//Date created: 10/7/24
//Purpose: To control visuals of the item slot as well as keeping track of items amounts

public class InventorySlotScript : MonoBehaviour, IPointerClickHandler
{
    //item data
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;

    //Visuals of the item slot
    [SerializeField]
    private Text quantityText;
    [SerializeField]
    private Image itemImage;

    //Description Variables
    public Image itemDescriptionImage;
    public Text ItemDescriptionNameText;
    public Text ItemDescriptionText;
    public ItemType itemType;

    //Selection graphics variables
    public GameObject selectedShader;
    public bool thisItemSelected;

    //Way for ItemSlots to talk to EquipmentSlots
    [SerializeField]
    private EquipmentSlotScript attackSlot, armorSlot, wildSlot;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, ItemType itemType)
    {
        //Updates all item info
        this.itemType = itemType;
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
            EquipGear();
        }
    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
    }

    private void EquipGear()
    {
        //Logic for what to do when placing each item in its respective slot
        if (itemType == ItemType.attack)
        {
            //Find a way to make this item go in wildcard slots also
            attackSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        if (itemType == ItemType.armor)
        {
            //Find a way to make this item go in wildcard slots also
            armorSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        if (itemType == ItemType.wild)
        {
            wildSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
    }
}
