using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Equipment : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite sprite;
    public string EquipmentName;
    public string description;
    public Vector2 descriptionPos;

    public void Init(Sprite sprite, string EquipmentName, string description, Vector2 descriptionPos)
    {
        this.sprite = sprite;
        this.EquipmentName = EquipmentName;
        this.description = description;
        this.descriptionPos = descriptionPos;
    }

    // 鼠标进入
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.25f, 0.25f);

        // 显示描述
        UIManager.Instance.ShowUI<DiscUI>("DiscUI");
        UIManager.Instance.GetUI<DiscUI>("DiscUI").Init(sprite, EquipmentName, description, descriptionPos);

        transform.Find("BG").GetComponent<Image>().material.SetColor("_lineColor", Color.yellow);
        transform.Find("BG").GetComponent<Image>().material.SetFloat("_lineWidth", 3);
    }

    // 鼠标离开
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1, 0.25f);
        
        UIManager.Instance.CloseUI("DiscUI");

        transform.Find("BG").GetComponent<Image>().material.SetColor("_lineColor", Color.white);
        transform.Find("BG").GetComponent<Image>().material.SetFloat("_lineWidth", 1);
    }
}
