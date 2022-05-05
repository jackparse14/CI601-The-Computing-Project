using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    public Item item;
    [SerializeField] public Image icon;
    [SerializeField] protected Image background;
    public Canvas iconCanvas;

    public virtual void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }
    public virtual void ClearItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
    public void OnClick()
    {
        if (item != null)
        {
            UIEvents.uIEvents.InventorySlotClicked(this);
        }
        else
        {
            UIEvents.uIEvents.InventorySlotEmptyClicked();
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (this is EquippedSlot equippedSlot)
            {
                UIEvents.uIEvents.EquippedSlotDroppedOn(equippedSlot);
            }
            else if (this is InventorySlot inventorySlot)
            {
                UIEvents.uIEvents.InventorySlotDroppedOn(inventorySlot);
            }
            else {
                Debug.Log("NEITHER EQUIP OR INVENTORY");
            }
        }
    }
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            if (this is EquippedSlot equippedSlot)
            {
                UIEvents.uIEvents.EquippedSlotDragStart(equippedSlot);
            }
            else if (this is InventorySlot inventorySlot)
            {
                UIEvents.uIEvents.InventorySlotDragStart(inventorySlot);
            }
            else
            {
                Debug.Log("NEITHER EQUIP OR INVENTORY");
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            
            UIEvents.uIEvents.InventorySlotOnDrag(eventData.position);
        }
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            if (this is EquippedSlot equippedSlot)
            {
                UIEvents.uIEvents.EquippedSlotDragEnd(equippedSlot);
            }
            else if (this is InventorySlot inventorySlot)
            {
                UIEvents.uIEvents.InventorySlotDragEnd(inventorySlot);
            }
            else
            {
                Debug.Log("NEITHER EQUIP OR INVENTORY");
            }
        }
    }
}
