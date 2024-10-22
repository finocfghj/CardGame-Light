using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// 所有的装备都在这里，实现定向抽取和随机抽取
/// </summary>
public class EquipmentInventory : MonoBehaviour
{
    public static EquipmentInventory Instance;

    public List<EquipmentBase> equipments;


    private void Awake()
    {
        Instance = this;
    }
    
    public EquipmentBase GetEquipmentRandomly()
    {
        return equipments[Random.Range(0,equipments.Count)];
    }

    public EquipmentBase GetEquipment(string name)
    {
        return equipments.FirstOrDefault(equipment => equipment.EquipmentName == name);
    }
}
