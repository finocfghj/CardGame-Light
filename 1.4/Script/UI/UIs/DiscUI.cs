using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DiscUI : UIBase
{
    public Image image;
    public TMP_Text desc;

    private void Awake()
    {
        image = transform.Find("Image").GetComponent<Image>();
        desc = GetComponentInChildren<TMP_Text>();
    }

    public void Init(Sprite sprite, string _name, string description, Vector2 pos)
    {
        image.sprite = sprite;
        this.desc.text = description;
    }
}
