using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : StatOutputterTab
{
    [SerializeField] private Text nameText;
    [SerializeField] private Image image;
    [SerializeField] private GameObject StatsParent;
    [SerializeField] private GameObject DescriptionParent;
    [SerializeField] private Text description;
    [SerializeField] private Text goldText;
    
    private void Start()
    {
        UIEvents.uIEvents.onSlotClicked += OnDisplayItemUI;
        UIEvents.uIEvents.onInventorySlotEmptyClicked += CloseTab;
        CloseTab();
    }

    private void OnDisplayItemUI(Slot slot) {
        if (slot is EquippedSlot && slot.item is EquipItem equipItem) {
            audioManager.PlaySound("UIClick");
            StatsParent.SetActive(true);
            DescriptionParent.SetActive(false);
            UpdateText(equipItem.speed.ToString(),
                            equipItem.strength.ToString(),
                            equipItem.armour.ToString(),
                            equipItem.intelligence.ToString(),
                            equipItem.health.ToString(),
                            equipItem.agility.ToString(),
                            equipItem.mana.ToString());
            goldText.text = equipItem.gold.ToString();
            SetIconAndName(equipItem);
        } else if (slot is InventorySlot) {
            
            if (slot.item is EquipItem equipItem2)
            {
                DisplayEquipItem(equipItem2);
            }
            else if (slot.item is NonEquipItem nonEquipItem)
            {
                DisplayNonEquipItem(nonEquipItem);
            }
        }
    }
    private void DisplayEquipItem(EquipItem item) {
        StatsParent.SetActive(true);
        DescriptionParent.SetActive(false);
        EquippedSlot[] equipmentSlots = EquippedInventory.instance.equipmentSlots;
        bool openTab = false;
        
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            Debug.Log(equipmentSlots[i].slotType);
            if (equipmentSlots[i].slotType == item.armourType && equipmentSlots[i].item == null)
            {
                UpdateText( item.speed.ToString(), 
                            item.strength.ToString(), 
                            item.armour.ToString(), 
                            item.intelligence.ToString(), 
                            item.health.ToString(), 
                            item.agility.ToString(), 
                            item.mana.ToString()
                );
                goldText.text = item.gold.ToString();
                openTab = true;
            }
        }
        if (openTab)
        {
            SetIconAndName(item);
        }
        else
        {
            CloseTab();
        }   
    }
    private void DisplayNonEquipItem(NonEquipItem item)
    {
        StatsParent.SetActive(false);
        DescriptionParent.SetActive(true);
        description.text = item.description.ToString();
        goldText.text = item.gold.ToString();
        SetIconAndName(item);
    }
    
    private void SetIconAndName(Item item) {
        image.sprite = item.icon;
        nameText.text = item.itemName;
        OpenTab();
    }

}