using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PurpleButton : NavigationButtons, IDropHandler
{
    private Color32 purpleColor = new Color32(215, 90, 255, 255);
    private List<Item> purpleList;
    private void Start()
    {
        purpleList = Inventory.instance.purpleItems;
    }
    public void OnClick() {
        ChooseCharacter(purpleColor, 3);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DroppedOn(purpleList);
        }
    }
}
