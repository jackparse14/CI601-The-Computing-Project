using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RedButton : NavigationButtons, IDropHandler
{
    private Color32 redColor = new Color32(255, 90, 90, 255);
    private List<Item> redList;
    private void Start()
    {
        redList = Inventory.instance.redItems;
    }
    public void OnClick() {
        ChooseCharacter(redColor, 0);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DroppedOn(redList);
        }
    }
}
