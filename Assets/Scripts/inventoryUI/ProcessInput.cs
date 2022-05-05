using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessInput : MonoBehaviour
{
    public RaycastUIElements raycastUIElements;
    public InventoryUI inventoryUI;
    private InventorySlot currentInvSlot;
    public PlayerController playerController;
    private void DestroyDropdowns() {
        if (inventoryUI.currentItemOptions != null)
        {
            inventoryUI.DestroyDropdownList();
        }
        if (inventoryUI.currentMoveDropdown != null)
        {
            inventoryUI.DestroyMoveList();
        }
    }
    public void ProcessRightClick(PlayerInputActions pia) {
        
        if (raycastUIElements.CheckIfHittingUI())
        {
            if (inventoryUI.isActiveAndEnabled)
            {
                StartCoroutine(raycastUIElements.CheckSearchBarClicked(pia));
            }
            ProcessUIRightClick(pia);
        }
        else
        {
            DestroyDropdowns();
            playerController.MoveOnClick(pia.Mouse.MousePos.ReadValue<Vector2>());
        }
    }
    public void ProcessLeftClick(PlayerInputActions pia, bool isAltLeftClickInProgress) {
        if (isAltLeftClickInProgress) { return; }
        
        if (raycastUIElements.CheckIfHittingUI()) {
            if (inventoryUI.isActiveAndEnabled) {
                StartCoroutine(raycastUIElements.CheckSearchBarClicked(pia));
            }
            ProcessUILeftClick();
        } else {
            RaycastToWorldPoint(pia);
        }
    }
    private void ProcessUIRightClick(PlayerInputActions pia) {
        
        GameObject element = raycastUIElements.GetUIElementsInUICanvas();
        if (element == null || !element.CompareTag("InventorySlotButton"))
        {
            DestroyDropdowns();
        }
        else {
            DestroyDropdowns();
            currentInvSlot = element.GetComponentInParent<InventorySlot>();
            inventoryUI.InstantiateDropdownList(currentInvSlot);
        }
    }
    private void ProcessUILeftClick()
    {
        if (inventoryUI.currentItemOptions != null)
        {
            
            GameObject element1 = raycastUIElements.GetUIElementsInInventorySlotOnClick(currentInvSlot);
            GameObject element2;
            if (inventoryUI.currentItemOptions.hasClickedOnce)
            {
                element2 = raycastUIElements.GetUIElementsInDropDownListOnClick();
                if (element2 != null)
                {
                    if (element2.tag != "OptionsDropdown")
                    {
                        inventoryUI.DestroyDropdownList();
                    }
                }
                else
                {
                    inventoryUI.DestroyDropdownList();
                }
            }
            else
            {
                CheckIfElementIsDropdown(element1, false);
            }
        }
        else if (inventoryUI.currentMoveDropdown != null)
        {
            GameObject element1 = raycastUIElements.GetUIElementsInInventorySlotOnClick(currentInvSlot);
            GameObject element2;
            if (inventoryUI.currentMoveDropdown.hasClickedOnce)
            {
                element2 = raycastUIElements.GetUIElementsInMoveDropDownListOnClick();
                if (element2 != null)
                {
                    if (element2.tag != "OptionsDropdown")
                    {
                        inventoryUI.DestroyMoveList();
                    }
                }
            }
            else
            {
                CheckIfElementIsDropdown(element1, true);
            }

        }
    }
    private void CheckIfElementIsDropdown(GameObject uiElement, bool isDestroyMove) {
        if (uiElement == null || uiElement.tag != "OptionsDropdown")
        {
                DestroyMoveOrOptionsDropdown(isDestroyMove);
        }
    }
    private void DestroyMoveOrOptionsDropdown(bool destroyMove) { 
            if (destroyMove)
            {
                inventoryUI.DestroyMoveList();
            }
            else
            {
                inventoryUI.DestroyDropdownList();
            }
    }
    private void RaycastToWorldPoint(PlayerInputActions pia) {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(pia.Mouse.MousePos.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (raycastUIElements.CheckIfHittingUI())
            {
                return;
            }
            if (hit.transform.gameObject.CompareTag("Item"))
            {
                hit.transform.gameObject.GetComponent<ItemPickUp>().PickUp();
            };
        };
    }
}
