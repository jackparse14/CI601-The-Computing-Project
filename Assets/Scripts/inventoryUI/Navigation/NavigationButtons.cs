using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationButtons : MonoBehaviour
{
    [SerializeField] private Image charImg;
    [SerializeField] private Image charInfoImg;
    private AudioManager audioManager;
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    protected void ChooseCharacter(Color32 charColor, int invIndex)
    {
        audioManager.PlaySound("UIClick");
        charImg.color = charColor;
        charInfoImg.color = charColor;
        Inventory.instance.SetActiveInv(invIndex);
        EquippedInventory.instance.SetActiveInv(invIndex);
    }
    protected void DroppedOn(List<Item> itemList) {
        UIEvents.uIEvents.NavigationDroppedOn(itemList);
    }
    
}
