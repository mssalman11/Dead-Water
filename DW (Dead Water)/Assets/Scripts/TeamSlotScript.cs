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

    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropping to " + gameObject.name);
    }
}
