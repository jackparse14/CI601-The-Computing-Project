using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlueButton : NavigationButtons, IDropHandler
{
    private Color32 blueColor = new Color32(90, 104, 255, 255);
    public List<Item> blueList;
    private void Start()
    {
        blueList = Inventory.instance.blueItems;
    }
    public void OnClick() {
        ChooseCharacter(blueColor, 1);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DroppedOn(blueList);
        }
    }
}
