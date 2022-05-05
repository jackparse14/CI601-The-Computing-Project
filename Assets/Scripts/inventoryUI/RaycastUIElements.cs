using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RaycastUIElements : MonoBehaviour
{
    public GameObject uiCanvas;
    GraphicRaycaster uiRaycaster;
    GraphicRaycaster slotRaycaster;
    PointerEventData clickData;
    List<RaycastResult> clickResults;
    InventoryUI inventoryUI;
    public InputField inputField;
    private bool areKeyboardActionsDisabled = false;
    private void Awake()
    {
        uiRaycaster = uiCanvas.GetComponent<GraphicRaycaster>();
        clickData = new PointerEventData(EventSystem.current);
        clickResults = new List<RaycastResult>();
        inventoryUI = FindObjectOfType<InventoryUI>();
    }
    public bool CheckIfHittingUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public GameObject GetUIElementsInDropDownListOnClick()
    {
        slotRaycaster = inventoryUI.currentItemOptions.GetComponentInChildren<GraphicRaycaster>();
        return GetUIElement(slotRaycaster);
    }
    public GameObject GetUIElementsInMoveDropDownListOnClick()
    {
        slotRaycaster = inventoryUI.currentMoveDropdown.GetComponentInParent<GraphicRaycaster>();
        return GetUIElement(slotRaycaster);
    }
    public GameObject GetUIElementsInInventorySlotOnClick(InventorySlot invSlot)
    {
        slotRaycaster = invSlot.iconCanvas.GetComponent<GraphicRaycaster>();
        return GetUIElement(slotRaycaster);
    }
    public GameObject GetUIElementsInUICanvas() {
        return GetUIElement(uiRaycaster);
    }
    private GameObject GetUIElement(GraphicRaycaster raycaster) {
        clickData.position = Mouse.current.position.ReadValue();
        clickResults.Clear();
        raycaster.Raycast(clickData, clickResults);
        foreach (RaycastResult result in clickResults)
        {
            GameObject element = result.gameObject;
            return element;
        }
        return null;
    }
    public IEnumerator CheckSearchBarClicked(PlayerInputActions pia)
    {
        yield return new WaitForSeconds(0.1f);
        if (inputField.isFocused && areKeyboardActionsDisabled == false)
        {
            pia.Keyboard.Disable();
            areKeyboardActionsDisabled = true;
        }
        else if (!inputField.isFocused && areKeyboardActionsDisabled == true)
        {
            pia.Keyboard.Enable();
            areKeyboardActionsDisabled = false;
        }
    }
}
