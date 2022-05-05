 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EquipType { NA, Head, Chest, LeftArm, RightArm, Legs, RightFoot, LeftFoot, Weapon, OffHand, Ring, Neck };
[CreateAssetMenu(fileName = "New Equip Item", menuName = "Inventory/EquipItem")]
public class EquipItem : Item
{
    public EquipType armourType;
    public float speed = 0;
    public float strength = 0;
    public float armour = 0;
    public float intelligence = 0;
    public float agility = 0;
    public float health = 0;
    public float mana = 0;
}
