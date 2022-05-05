using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquippedSlot : Slot, IDropHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image backdropImage;
    public EquipType slotType;
    public int slotIndex;
    public override void AddItem(Item newItem)
    { 
        base.AddItem(newItem);
        backdropImage.enabled = false;
    }
    public override void ClearItem()
    {
        base.ClearItem();
        backdropImage.enabled = true;
    }
}
