using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Light,
    Armor,
    Weapon
}

[CreateAssetMenu(fileName = "Inventory/EquipmentBase", menuName = "New Equipment Difinition")]
public class EquipmentBase : ScriptableObject
{
    public EquipmentType type;
    public int price;
    public int modifier;
}
