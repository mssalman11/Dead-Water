using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * Author: Leland LeVassar
 * Created 9/18/24
 * Purpose: To control logic for the Dungeon Team slot accepting a character card
 */

public class TeamSlotScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //IPointerHandlers are required for this to work. Make sure their associated functions are in the script.

    //SAVE BELOW CODE FOR GEAR EQUIPPING LOGIC
    public DragDropScript.Slot teamPos = DragDropScript.Slot.leftSide;
    //END OF POSSIBLE GEAR EQUIP LOGIC

    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        DragDropScript drag = eventData.pointerDrag.GetComponent<DragDropScript>();
        if (drag != null)
        {
            //Makes sure more than one item can't be put in slot
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DragDropScript draggableItem = dropped.GetComponent<DragDropScript>();
                draggableItem.returnPoint = transform;
            }
            else
            {

            }
        }
    }
    /*
     * //SAVE BELOW CODE FOR GEAR EQUIPPING LOGIC
                if (teamPos == drag.teamPos)
                {
                    drag.returnPoint = this.transform;
                }
                //END OF POSSIBLE GEAR EQUIP LOGIC
     */
}
