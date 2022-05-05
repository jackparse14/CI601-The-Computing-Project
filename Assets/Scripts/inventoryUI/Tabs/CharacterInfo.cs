using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : StatOutputterTab
{
    private float speed;
    private float strength;
    private float armour;
    private float intelligence;
    private float agility;
    private float health;
    private float mana;
    
    private void Start()
    {
        UIEvents.uIEvents.onEquippedInventoryChange += UpdateStats;
    }
    private void UpdateStats()
    {
        EquipItem[] activeItems = EquippedInventory.instance.equippedActiveItems;
        speed = 0;
        strength = 0;
        armour = 0;
        intelligence = 0;
        agility = 0;
        health = 0;
        mana = 0;
        for (int i = 0; i < activeItems.Length; i++)
        {
            if (activeItems[i] != null) {
                speed += activeItems[i].speed;
                strength += activeItems[i].strength;
                armour += activeItems[i].armour;
                intelligence += activeItems[i].intelligence;
                agility += activeItems[i].agility;
                health += activeItems[i].health;
                mana += activeItems[i].mana;
            }
        }
        UpdateText( speed.ToString(), 
                    strength.ToString(), 
                    armour.ToString(), 
                    intelligence.ToString(),
                    health.ToString(),
                    agility.ToString(), 
                    mana.ToString()
        );
    }
    public override void OpenTab()
    {
        base.OpenTab();
        audioManager.PlaySound("UIClick");
    }
    public override void CloseTab()
    {
        base.CloseTab();
        audioManager.PlaySound("Remove");
    }
}
