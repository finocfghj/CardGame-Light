using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardDifinition
{
    CardBase card;
    public Sprite _sprite=>card._sprite;
    public float cost=>card.cost;
    public string name=>card._name;
    public bool canSeek=>card.canSeek;
    public EnemyStat enemy;
    public string description=>card.description;


    public CardDifinition(Sprite sprite, float cost, string name, bool canSeek, string description)
    {
        card._sprite = sprite;
        card.cost = cost;
        card.name = name;
        card.canSeek = canSeek;
        enemy = null;
        card.description = description;
    }

    public virtual void TakeEffect()
    {

    }
}
