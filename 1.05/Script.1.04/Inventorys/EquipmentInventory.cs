using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventory : MonoBehaviour
{
    public static EquipmentInventory Instance;

    [SerializeField] List<EquipmentBase> equipments;

    public List<EquipmentBase> AttackEquipment;
    public List<EquipmentBase> ArmorEquipment;
    public List <EquipmentBase> LightEquipment;

    private void Awake()
    {
        Instance = this;

        foreach (var equipment in equipments)
        {
            if (equipment.type == EquipmentType.Weapon)
            {
                AttackEquipment.Add(equipment);
            }
            else if(equipment.type == EquipmentType.Armor)
            {
                ArmorEquipment.Add(equipment);
            }
            else
            {
                LightEquipment.Add(equipment);
            }
        }
    }
    
    public EquipmentBase GetEquipmentRandomly()
    {
        return equipments[Random.Range(0,equipments.Count)];
    }

    public EquipmentBase GetEquipmentRandomlyByType(EquipmentType type)
    {
        if (type == EquipmentType.Weapon)
        {
            return AttackEquipment[Random.Range(0, AttackEquipment.Count)];
        }
        else if (type == EquipmentType.Armor)
        {
            return ArmorEquipment[Random.Range(0, ArmorEquipment.Count)];
        }
        return LightEquipment[Random.Range(0, LightEquipment.Count)];
    }
}
