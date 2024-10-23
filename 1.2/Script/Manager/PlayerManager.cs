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

    // 初始化角色拥有的卡牌
    public void Awake()
    {
        Instance = this;
        equipList = new List<EquipmentBase>();
        MaxHp = 20;
        LightPower = 15;
    }

    public void Init()
    {
        hp=MaxHp;
    }

    public void AddEquipment(EquipmentBase equipment)
    {
        equipList.Add(equipment);
        //通知ui
    }

    public int DoDamage(int damage)
    {
        for(int i = 0; i < equipList.Count; i++)
        {
            if (equipList[i].name == "棍棒")
                damage += 2;
            if (equipList[i].name == "宝剑")
                damage += 4;
        }
        return damage;
    }

    public int GetDamaged(int damage)
    {
        return damage;
    }
}
