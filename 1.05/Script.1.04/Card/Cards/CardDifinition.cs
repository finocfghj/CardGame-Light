using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardDifinition
{
    CardBase card;
    public Sprite _sprite => card._sprite;
    public string name => card._name;
    public bool canSeek => card.canSeek;
    public string description => card.description;
    public CardType type => card.type;
    public int targetNumber => card.targetNumber;


    public CardDifinition(Sprite sprite, string name, bool canSeek, string description ,CardType type)
    {
        card._sprite = sprite;
        card.name = name;
        card.canSeek = canSeek;
        card.description = description;
        card.type = type;
    }

    public CardDifinition(CardBase card)
    {
        this.card = card;
    }

    public CardDifinition() { }

    public virtual bool TakeEffect()
    {
        return true;
    }
}
