using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardDifinition
{
    public Sprite _sprite;
    public float cost;//加费卡的费用是负的
    public string name;
    public bool canSeek;//是否可以以敌人为对象释放
    public EnemyStat enemy;
    public string description;//卡牌描述


    public CardDifinition(Sprite sprite, float cost, string name, bool canSeek, string description)
    {
        _sprite = sprite;
        this.cost = cost;
        this.name = name;
        this.canSeek = canSeek;
        enemy = null;
        this.description = description;
    }
}
