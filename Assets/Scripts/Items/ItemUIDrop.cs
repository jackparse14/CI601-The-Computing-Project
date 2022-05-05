using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemUIDrop : MonoBehaviour, IDropHandler
{
    public InventorySlot slot;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            UIEvents.uIEvents.InventorySlotDroppedOn(eventData.pointerDrag.GetComponent<InventorySlot>());
            
        }
    }
}
