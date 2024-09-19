using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * Author: Leland LeVassar w/ help from quill18creates tutorial on drag and drop
 * Created 9/18/24
 * Purpose: Controls logic for draggable objects, mainly our character cards in the main menu
 */

public class DragDropScript : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //IDragHandler lets Unity know we will be using drag function and that it will be present in the script
    //Make sure IDragHandler is active above if using drag 

    //Return point if card is dragged to an invalid location
    Transform returnPoint = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag activated");
        returnPoint = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
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
    }
}
