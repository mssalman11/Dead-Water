using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * Author: Leland LeVassar
 * Created 10/6/24
 * Purpose: To control logic for the gear equipping based on item type
 */

public class EquipmentSlotScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //IPointerHandlers are required for this to work. Make sure their associated functions are in the script.

    public EquipmentDragScript.Slot ItemType = EquipmentDragScript.Slot.attackSlot;

    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        EquipmentDragScript drag = eventData.pointerDrag.GetComponent<EquipmentDragScript>();
        if (drag != null)
        {
            //Makes sure more than one item can't be put in slot
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                EquipmentDragScript draggableItem = dropped.GetComponent<EquipmentDragScript>();
                draggableItem.returnPoint = transform;
            }
            //Restricting non wildcard items to their respective slots.
            
        }
    }
}
