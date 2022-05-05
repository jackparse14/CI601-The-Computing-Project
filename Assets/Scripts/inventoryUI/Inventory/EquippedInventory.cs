using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedInventory : MonoBehaviour
{
    private EquipItem[] equippedRedItems = new EquipItem[12];
    private EquipItem[] equippedBlueItems = new EquipItem[12];
    private EquipItem[] equippedPurpleItems = new EquipItem[12];
    private EquipItem[] equippedGreenItems = new EquipItem[12];
    public EquipItem[] equippedActiveItems;
    public Transform equipmentParent;
    public EquippedSlot[] equipmentSlots;
    public static EquippedInventory instance;
    public delegate void OnEquippedItemChanged();
    public OnEquippedItemChanged onEquippedItemChangedCallback;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of EquippedInventory found!");
        }
        else
        {
            instance = this;
        }
        equippedActiveItems = equippedRedItems;
        equipmentSlots = equipmentParent.GetComponentsInChildren<EquippedSlot>();
    }
    public void SetActiveInv(int ID)
    {
        if (ID == 0)
        {
            equippedActiveItems = equippedRedItems;
        }
        else if (ID == 1)
        {
            equippedActiveItems = equippedBlueItems;
        }
        else if (ID == 2)
        {
            equippedActiveItems = equippedGreenItems;
        }
        else if (ID == 3)
        {
            equippedActiveItems = equippedPurpleItems;
        }
        else
        {
            Debug.Log("ERROR ID INVALID");
        }
        InvokeEquippedItemChangedCallback();
    }
    public void MoveItemFromEquipped(List<Item> listToMoveTo, EquippedSlot slot)
    {
        listToMoveTo.Add(slot.item);
        equippedActiveItems[slot.slotIndex] = null;
        InvokeEquippedItemChangedCallback();
    }
    public bool Add(EquipItem item, int invSlot)
    {
        equippedActiveItems[invSlot] = item;
        InvokeEquippedItemChangedCallback();
        return true;
    }
    
    public void Remove(int invSlot)
    {
        equippedActiveItems[invSlot] = null;
        InvokeEquippedItemChangedCallback();
    }
    private void InvokeEquippedItemChangedCallback()
    {
        if (onEquippedItemChangedCallback != null)
        {
            onEquippedItemChangedCallback.Invoke();
        }
    }
}
