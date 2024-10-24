using System;
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
    // UI位置
    Dictionary<string, Vector2> EquipmentPos = new() {
        {"First", new Vector2(-380,0)},
        {"Second", new Vector2(0,0)},
        {"Third", new Vector2(380,0)}
    };

    public Equipment first;
    public Equipment second;
    public Equipment third;

    private void Awake()
    {
    }

    GameObject obj;
    Equipment item;
    public void CreateEquipmentItem(Sprite sprite, string name, string disc, Vector2 discPos)
    {
        obj = Instantiate(Resources.Load("UI/Equipment"), transform) as GameObject;

        item = obj.AddComponent<Equipment>();
        item.Init(sprite, name, disc, discPos);

        switch (PlayerManager.Instance.equipments.Count)
        {
            case 0:
                obj.GetComponent<RectTransform>().anchoredPosition = EquipmentPos["First"];
                first = item;
                break;
            case 1:
                obj.GetComponent<RectTransform>().anchoredPosition = EquipmentPos["Second"];
                second = item;
                break;
            case 2:
                obj.GetComponent<RectTransform>().anchoredPosition = EquipmentPos["Third"];
                third = item;
                break;
            case 3:
                SelectEquipment();
                break;
            default:
                break;
        }

        PlayerManager.Instance.AddEquipment(item);
    }

    private void SelectEquipment()
    {
        Register("First").onClick = onChooseFirst;
        Register("Second").onClick = onChooseSecond;
        Register("Third").onClick = onChooseThird;
    }

    private void onChooseFirst(GameObject @object, PointerEventData data)
    {
        DeleteEquipmentUI(first);
        obj.GetComponent<RectTransform>().anchoredPosition = EquipmentPos["First"];
        first = item;
    }

    private void onChooseSecond(GameObject @object, PointerEventData data)
    {
        DeleteEquipmentUI(second);
        obj.GetComponent<RectTransform>().anchoredPosition = EquipmentPos["second"];
        second = item;
    }

    private void onChooseThird(GameObject @object, PointerEventData data)
    {
        DeleteEquipmentUI(third);
        obj.GetComponent<RectTransform>().anchoredPosition = EquipmentPos["Third"];
        third = item;
    }

    public void DeleteEquipmentUI(Equipment equipment)
    {
        // 从集合中删除
        PlayerManager.Instance.RemoveEquipment(equipment);

        Destroy(equipment.gameObject, 1);
    }

    public void ClearEquipment()
    {

    }
}
