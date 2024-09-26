using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    private Item currItem;
    public Image cusCur;

    public Slot[] craftingSlots;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (currItem != null)
            {
                cusCur.gameObject.SetActive(false);
                Slot nearestSlot = null;
                float shortestDistance = float.MaxValue;

                foreach (Slot slot in craftingSlots)
                {

                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

                    if (dist < shortestDistance)
                    {
                        shortestDistance = dist;
                        nearestSlot = slot;
                    }
                }

                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currItem.GetComponent<Image>().sprite;
                nearestSlot.item = currItem;
                currItem = null;
            }
        }
    }

        public void OnMouseDownItem(Item item)
        {
            if (currItem == null)
            {
                currItem = item;
                cusCur.gameObject.SetActive(true);
                cusCur.sprite = currItem.GetComponent<Image>().sprite;
            }
        }
    }
