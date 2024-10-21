using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory/EquipmentBase", menuName = "New Equipment Difinition")]
public class EquipmentBase : ScriptableObject
{
    public Sprite sprite;
    public string EquipmentName;
    public string description;
}