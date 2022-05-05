using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOptions : MonoBehaviour
{
    public Canvas parentCanvas;
    private InventoryUI invUI;
    public MoveDropdown moveDropdownPrefab;
    private InventorySlot invSlot;
    public bool hasClickedOnce = false;
    private void Start()
    {
        invUI = FindObjectOfType<InventoryUI>();
        parentCanvas = GetComponentInParent<Canvas>();
    }
    public void DestroySelf()
    {
        hasClickedOnce = false;
        parentCanvas.sortingOrder = 1;
        Destroy(gameObject);
    }
    public void SetInventorySlot(InventorySlot slot) {
        invSlot = slot;
    }
    public void DropdownClicked() {
       hasClickedOnce = true;
    }
    public void HandleDropdownInput(int val)
    {
        switch (val) {
            case 0:
                InstantiateMoveDropDown();
                break;
            case 1:
                if (invSlot.item is EquipItem equipItem) {
                    for (int i = 0; i < invUI.equippedSlots.Length; i++)
                    {
                        if (invUI.equippedSlots[i].slotType == equipItem.armourType)
                        {
                            UIEvents.uIEvents.EquippedSlotDroppedOn(invUI.equippedSlots[i]); ;
                        }
                    }
                }
                break;
            case 2:
                UIEvents.uIEvents.InventorySlotClicked(invSlot);
                invUI.currentInventorySlot = null;
                break;
        }
        DestroySelf();
    }
    private void InstantiateMoveDropDown(){
        invUI.currentMoveDropdown = Instantiate(moveDropdownPrefab, parentCanvas.transform);
    }
}
