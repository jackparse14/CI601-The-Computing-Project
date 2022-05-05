using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GreenButton : NavigationButtons, IDropHandler
{
    private Color32 greenColor = new Color32(90, 255, 112, 255);
    private List<Item> greenList;
    private void Start()
    {
        greenList = Inventory.instance.greenItems;
    }
    public void OnClick() {
        ChooseCharacter(greenColor, 2);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DroppedOn(greenList);
        }
    }
}
