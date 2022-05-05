using UnityEngine;
public enum ItemType { Armour, Weapons, Utility, Crafting, KeyItem, Junk };

public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public ItemType itemType;
    public float gold = 0;
}