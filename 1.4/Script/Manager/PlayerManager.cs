using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

/// <summary>
/// 角色信息
/// </summary>
public class PlayerManager:MonoBehaviour
{
    public static PlayerManager Instance;

    //装备可以叠加时需要下述列表,应该需要UI
    public List<EquipmentBase> equipments;

    // 角色的其他信息
    public int MaxHp;
    public int hp;
    public int LightPower;

    // 初始化角色拥有的卡牌
    public void Awake()
    {
        Instance = this;
        equipments = new List<EquipmentBase>();
        MaxHp = 20;
        LightPower = 10;
    }

    public void Init()
    {
        hp=MaxHp;
    }

    public void AddEquipment(Equipment item)
    {
        EquipmentBase newEquipment = EquipmentInventory.Instance.GetEquipment(item.EquipmentName);

        equipments.Add(newEquipment);
    }

    public void RemoveEquipment(Equipment equipment)
    {
        EquipmentBase newEquipment = EquipmentInventory.Instance.GetEquipment(equipment.EquipmentName);
        equipments.Remove(newEquipment);
    }

        public int DoDamage(int damage)
    {
        for(int i = 0; i < equipments.Count; i++)
        {
            if (equipments[i].EquipmentName == "棍棒")
                damage += 2;
            if (equipments[i].EquipmentName == "宝剑")
                damage += 4;
            if (equipments[i].EquipmentName == "双刀")
                damage += 3;
        }
        return damage;
    }

    public int GetDamaged(int damage)
    {
        return damage;
    }

    public int DoLight(int light)
    {
        for (int i = 0; i < equipments.Count; i++)
        {
            if (equipments[i].EquipmentName == "法杖")
                light += 10;
        }
        return light;
    }

}
