using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CompareUI : StatOutputterTab
{
    //  Equipped
    [SerializeField] private Image equippedImage;
    [SerializeField] private Text equippedNameText;
    [SerializeField] private Text equippedGoldText;

    //  Compare
    [SerializeField] private Image compareImage;
    [SerializeField] private Text compareNameText;
    [SerializeField] private Text compareSpeedModifierText;
    [SerializeField] private Text compareStrengthModifierText;
    [SerializeField] private Text compareArmourModifierText;
    [SerializeField] private Text compareIntelligenceModifierText;
    [SerializeField] private Text compareAgilityModifierText;
    [SerializeField] private Text compareHealthModifierText;
    [SerializeField] private Text compareManaModifierText;
    [SerializeField] private Text compareGoldText;

    [SerializeField] private Text betterWorseSpeedModifierText;
    [SerializeField] private Text betterWorseStrengthModifierText;
    [SerializeField] private Text betterWorseArmourModifierText;
    [SerializeField] private Text betterWorseIntelligenceModifierText;
    [SerializeField] private Text betterWorseAgilityModifierText;
    [SerializeField] private Text betterWorseHealthModifierText;
    [SerializeField] private Text betterWorseManaModifierText;

    private Color32 redColor = new Color32(186, 12, 0, 255);
    private Color32 greenColor = new Color32(0, 128, 34, 255);
    void Start()
    {
        
        UIEvents.uIEvents.onSlotClicked += OnDisplayCompareUI;
        UIEvents.uIEvents.onInventorySlotEmptyClicked += CloseTab;
        CloseTab();
    }
    public void OnDisplayCompareUI(Slot slot)
    {
        if (slot is EquippedSlot) {
            CloseTab();
            return;
        }
        if (slot.item is EquipItem equipItem)
        {
            int itemIndex = -1;
            EquipItem[] activeItems = EquippedInventory.instance.equippedActiveItems;
            for (int i = 0; i < activeItems.Length; i++)
            {
                if (activeItems[i] != null && activeItems[i].armourType == equipItem.armourType)
                {
                    itemIndex = i;
                }
            }
            if (itemIndex != -1)
            {
                DisplayCompareStats(equipItem);
                DisplayBetterWorseStats(activeItems[itemIndex], equipItem);
                DisplayEquippedStats(activeItems[itemIndex]);
                audioManager.PlaySound("UIClick");
                OpenTab();
            }
            else
            {
                audioManager.PlaySound("UIClick");
                CloseTab();
            }
        }
        else if (slot.item is NonEquipItem) {
            audioManager.PlaySound("UIClick");
            CloseTab();
        }
        
    }
    private void DisplayEquippedStats(EquipItem item) {
        equippedImage.sprite = item.icon;
        equippedNameText.text = item.itemName;
        UpdateText( item.speed.ToString(), 
                    item.strength.ToString(), 
                    item.armour.ToString(), 
                    item.intelligence.ToString(), 
                    item.agility.ToString(), 
                    item.health.ToString(), 
                    item.mana.ToString()
        );
        equippedGoldText.text = item.gold.ToString();
    }
    private void DisplayCompareStats(EquipItem item)
    {
        compareImage.sprite = item.icon;
        compareNameText.text = item.itemName;
        compareSpeedModifierText.text = item.speed.ToString();
        compareStrengthModifierText.text = item.strength.ToString();
        compareArmourModifierText.text = item.armour.ToString();
        compareIntelligenceModifierText.text = item.intelligence.ToString();
        compareAgilityModifierText.text = item.agility.ToString();
        compareHealthModifierText.text = item.health.ToString();
        compareManaModifierText.text = item.mana.ToString();
        compareGoldText.text = item.gold.ToString();
    }
    private void DisplayBetterWorseStats(EquipItem equipped, EquipItem compare) {
        CalculateBetterWorseStats(equipped.speed,compare.speed,betterWorseSpeedModifierText);
        CalculateBetterWorseStats(equipped.strength, compare.strength, betterWorseStrengthModifierText);
        CalculateBetterWorseStats(equipped.armour, compare.armour, betterWorseArmourModifierText);
        CalculateBetterWorseStats(equipped.intelligence, compare.intelligence, betterWorseIntelligenceModifierText);
        CalculateBetterWorseStats(equipped.agility, compare.agility, betterWorseAgilityModifierText);
        CalculateBetterWorseStats(equipped.health, compare.health, betterWorseHealthModifierText);
        CalculateBetterWorseStats(equipped.mana, compare.mana, betterWorseManaModifierText);
    }
    private void CalculateBetterWorseStats(float equippedStat, float compareStat,Text text) {
        if (equippedStat > compareStat)
        {
            text.text = " (-" + (equippedStat - compareStat).ToString() + ")";
            text.color = redColor;
        }
        else if (equippedStat == compareStat)
        {
            text.text = "";
            text.color = Color.black;
        }
        else
        {
            text.text = " (+" + (compareStat - equippedStat).ToString() + ")";
            text.color = greenColor;
        }
    }
}
