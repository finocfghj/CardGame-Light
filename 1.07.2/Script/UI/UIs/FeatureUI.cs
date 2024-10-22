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
    public void Init(EnemyBase enemy)
    {
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TMP_Text>();
        text.text = enemy.features;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Close();
    }
}
