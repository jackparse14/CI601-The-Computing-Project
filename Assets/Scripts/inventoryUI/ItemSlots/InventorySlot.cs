using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : Slot
{
    [SerializeField] private Button removeButton;
    public override void AddItem(Item newItem)
    {
        base.AddItem(newItem);
        EnableRemoveButton();
    }
    public override void ClearItem()
    {
        base.ClearItem();
        DisableRemoveButton();
    }
    public void OnRemoveButton()
    {
        UIEvents.uIEvents.InventorySlotRemoveClicked(this);
    }
    private void DisableRemoveButton()
    {
        removeButton.interactable = false;
    }
    private void EnableRemoveButton() {
        removeButton.interactable = true;
    }
    public void HighlightSlot()
    {
        background.color = new Color32(255, 90, 90, 255);
    }
    public void UnhighlightSlot()
    {
        background.color = new Color32(255, 255, 255, 255);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        if (item != null)
        {
            DisableRemoveButton();
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (item != null)
        {
            EnableRemoveButton();
        }
    }
}