using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 装备UI
/// </summary>
public class EquipmentUI : UIBase
{
    private void Awake()
    {

    }

    public void CreateEquipmentItem(Sprite sprite, string name, string disc, Vector2 discPos)
    {
        GameObject obj = Instantiate(Resources.Load("UI/Equipment"), transform) as GameObject;
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(1000, -600);

        // 获得添加的装备是什么装备
        // 然后添加对应的装备脚本

        Equipment item = obj.AddComponent<Equipment>();
        item.Init(sprite, name, disc, discPos);

        EquipmentInventory.Instance.AddEquipment(item);
    }

    public void DeleteEquipmentUI(Equipment equipment)
    {
        // 从集合中删除
        EquipmentInventory.Instance.RemoveEquipment(equipment);

        Destroy(equipment.gameObject, 1);
    }

    public void ClearEquipment()
    {
        
    }
}
