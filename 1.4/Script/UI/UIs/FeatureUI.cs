using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FeatureUI : UIBase,IPointerClickHandler
{
    public Image image;
    public TMP_Text text;
    public void Init(EnemyStat enemy)
    {
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TMP_Text>();
        if (enemy.equipment != null && enemy.enemy.features != null)
            text.text = enemy.equipment.EquipmentName + ':' + enemy.equipment.description + '\n' + enemy.enemy.features;
        else if (enemy.equipment != null)
            text.text = enemy.equipment.EquipmentName + ':' + enemy.equipment.description;
        else if (enemy.enemy.features != null) 
            text.text = enemy.enemy.features;
        else
            text.text = "нч";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Close();
    }
}
