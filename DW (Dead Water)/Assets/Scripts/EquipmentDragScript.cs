using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * Author: Leland LeVassar
 * Created 10/6/24
 * Purpose: Controls logic for items and their tags that determine the type of item they are
 */

public class EquipmentDragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //IDragHandler lets Unity know we will be using drag function and that it will be present in the script
    //Make sure IDragHandler is active above if using drag 

    //Return point if card is dragged to an invalid location
    public Transform returnPoint = null;

    //SAVE BELOW CODE FOR GEAR EQUIPPING LOGIC
    public enum Slot { attackSlot, armorSlot, wildSlot };
    public Slot itemType = Slot.attackSlot;
    //END OF POSSIBLE GEAR EQUIP LOGIC

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag activated");
        returnPoint = this.transform.parent;
        this.transform.SetParent(this.transform.root);
        this.transform.SetAsLastSibling();

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag activated");

        this.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag activated");
        this.transform.SetParent(returnPoint);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
