using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色信息
/// </summary>
public class PlayerManager:MonoBehaviour
{
    public static PlayerManager Instance;

    //装备可以叠加时需要下述列表,应该需要UI
    public List<EquipmentBase> equipList;

    // 角色的其他信息
    public int MaxHp;
    public int hp;
    public int LightPower;
    public int ArmorPower;
    public int WeaponPower;

    // 初始化角色拥有的卡牌
    public void Start()
    {
        Instance = this;
        equipList = new List<EquipmentBase>();
        MaxHp = 10;
    }

    public void Init()
    {
        hp=MaxHp;
    }

    public void ArmEquipment(EquipmentBase equipment)
    {
        //假设装备不能叠加
        if (equipment.type == EquipmentType.Weapon) WeaponPower = equipment.modifier;
        else if (equipment.type == EquipmentType.Armor) ArmorPower = equipment.modifier;
        else LightPower = equipment.modifier;
    }

    public void AddEquipment(EquipmentBase equipment)
    {
        equipList.Add(equipment);
        //通知ui？
    }
}
