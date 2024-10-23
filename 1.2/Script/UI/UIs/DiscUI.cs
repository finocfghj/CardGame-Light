using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DiscUI : UIBase
{
    public Sprite sprite;
    public TMP_Text _name;
    public TMP_Text desc;
    public Vector2 pos;

    private void Awake()
    {
         
    }

    public void Init(Sprite sprite, string _name, string description, Vector2 pos)
    {
        this.sprite = sprite;
        this._name.text = _name;
        this.desc.text = description;
        this.pos = pos;
    }
}
