using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlotScript : MonoBehaviour
{
    public string itemName;
    public int quantity;
    public bool isFull;

    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image itemImage;

    public void AddItem()
    {

    }
}
