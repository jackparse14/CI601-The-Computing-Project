using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDropdown : MonoBehaviour
{
    public Canvas parentCanvas;
    private InventoryUI inventoryUI;
    public bool hasClickedOnce = false;
    private void Start()
    {
        parentCanvas = GetComponentInParent<Canvas>();
        parentCanvas.sortingOrder = 10;
        inventoryUI = FindObjectOfType<InventoryUI>();
    }
    public void DropdownClicked()
    {
        hasClickedOnce = true;
    }
    public void HandleMoveDropdownInput(int val) {
        switch (val)
        {
            case 0:
                UIEvents.uIEvents.NavigationDroppedOn(Inventory.instance.redItems);
                break;
            case 1:
                UIEvents.uIEvents.NavigationDroppedOn(Inventory.instance.blueItems);
                break;
            case 2:
                UIEvents.uIEvents.NavigationDroppedOn(Inventory.instance.greenItems);
                break;
            case 3:
                UIEvents.uIEvents.NavigationDroppedOn(Inventory.instance.purpleItems);
                break;
        }
        inventoryUI.currentInventorySlot = null;
        DestroySelf();
    }
    public void DestroySelf()
    {
        hasClickedOnce = false;
        parentCanvas.sortingOrder = 1;
        Destroy(gameObject);
    }
}
