using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Event Class is Observer Pattern
public class UIEvents : MonoBehaviour
{
    public static UIEvents uIEvents;
    // Singleton Pattern
    void Awake()
    {
        uIEvents = this;
    }
    //  Equipped Slots
    public event Action<EquippedSlot> onEquippedSlotDragEnd;
    public event Action<EquippedSlot> onEquippedSlotDragStart;
    public event Action<EquippedSlot> onEquippedSlotDroppedOn;

    // Inventory Slots
    public event Action<Slot> onSlotClicked;
    public event Action onInventorySlotEmptyClicked;
    public event Action<InventorySlot> onInventorySlotRemoveClicked;
    public event Action<InventorySlot> onInventorySlotDragEnd;
    public event Action<InventorySlot> onInventorySlotDroppedOn;
    public event Action<InventorySlot> onInventorySlotDragStart;
    public event Action<Vector2> onInventorySlotOnDrag;

    // Inventory Warning
    public event Action<String> onInventoryIsFull;

    //  Navigation
    public event Action<List<Item>> onNavigationDroppedOn;

    //  Sort Functions
    public event Action<Dictionary<int,bool>> onSort;

    //  Character Info
    public event Action onEquippedInventoryChange;

    /*----------------------------------------------------------------------------------------*/

    //  Inventory Warning
    public void InventoryIsFull(string player) {
        if (onInventoryIsFull != null) {
            onInventoryIsFull(player);
        } else {
            Debug.Log("onInventoryIsFull Event is NULL");
        }
    }
    //  Character Info
    public void EquippedInventoryChange()
    {
        if (onEquippedInventoryChange != null)
        {
            onEquippedInventoryChange();
        }
        else
        {
            Debug.Log("onEquippedInventoryChange Event is NULL");
        }
    }

    //  Navigation
    public void NavigationDroppedOn(List<Item> listToMoveTo) {
        if (onNavigationDroppedOn != null)
        {
            onNavigationDroppedOn(listToMoveTo);
        }
        else
        {
            Debug.Log("onNavigationDroppedOn Event is NULL");
        }
    }
    // Equipped Slots
    public void EquippedSlotDroppedOn(EquippedSlot slot) {
        if (onEquippedSlotDroppedOn != null)
        {
            onEquippedSlotDroppedOn(slot);
        }
        else
        {
            Debug.Log("onEquippedSlotDroppedOn Event is NULL");
        }
    }
    public void EquippedSlotDragEnd(EquippedSlot slot)
    {
        if (onEquippedSlotDragEnd != null)
        {
            onEquippedSlotDragEnd(slot);
        }
        else
        {
            Debug.Log("onEquippedSlotDragEnd Event is NULL");
        }
    }
    public void EquippedSlotDragStart(EquippedSlot slot)
    {
        if (onEquippedSlotDragStart != null)
        {
            onEquippedSlotDragStart(slot);
        }
        else
        {
            Debug.Log("onEquippedSlotDragStart Event is NULL");
        }
    }

    // Inventory Slots
    public void InventorySlotClicked(Slot slot) {
        if (onSlotClicked != null)
        {
            onSlotClicked(slot);
        } else {
            Debug.Log("onInventorySlotClicked Event is NULL");
        }
    }
    public void InventorySlotEmptyClicked() {
        if (onInventorySlotEmptyClicked != null)
        {
            onInventorySlotEmptyClicked();
        } else {
            Debug.Log("onInventorySlotEmptyClicked Event is NULL");
        }
    }
    public void InventorySlotRemoveClicked(InventorySlot slot) {
        if (onInventorySlotRemoveClicked != null)
        {
            onInventorySlotRemoveClicked(slot);
        } else {
            Debug.Log("onInventorySlotRemoveClicked Event is NULL");
        }
    }
    public void InventorySlotDragStart(InventorySlot slot)
    {
        if (onInventorySlotDragStart != null)
        {
            onInventorySlotDragStart(slot);
        }
        else
        {
            Debug.Log("onInventorySlotDragStart Event is NULL");
        }
    }
    public void InventorySlotDragEnd(InventorySlot slot)
    {
        if (onInventorySlotDragEnd != null)
        {
            onInventorySlotDragEnd(slot);
        }
        else
        {
            Debug.Log("onInventorySlotDragEnd Event is NULL");
        }
    }
    public void InventorySlotDroppedOn(InventorySlot slot)
    {
        if (onInventorySlotDroppedOn != null)
        {
            onInventorySlotDroppedOn(slot);
        }
        else
        {
            Debug.Log("onInventorySlotDroppedOn Event is NULL");
        }
    }
    public void InventorySlotOnDrag(Vector2 currMousePosition)
    {
        if (onInventorySlotOnDrag != null)
        {
            onInventorySlotOnDrag(currMousePosition);
        }
        else
        {
            Debug.Log("onInventorySlotOnDrag Event is NULL");
        }
    }

    //  Sort Functions
    public void Sort(Dictionary<int, bool> highlightSlotIndex)
    {
        if (onSort != null)
        {
            onSort(highlightSlotIndex);
        }
        else
        {
            Debug.Log("onSort Event is NULL");
        }
    }
}
