using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class CardDifinition
{
    // 卡牌信息
    public CardBase cardData;
    public Sprite _sprite => cardData._sprite;
    public string _name => cardData._name;
    public bool canSeek => cardData.canSeek;
    public string description => cardData.description;
    public CardType type => cardData.type;
    public int targetNumber => cardData.targetNumber;

    public CardDifinition(Sprite sprite, string name, bool canSeek, string description, CardType type)
    {
        cardData._sprite = sprite;
        cardData.name = name;
        cardData.canSeek = canSeek;
        cardData.description = description;
        cardData.type = type;
    }

    public CardDifinition(CardBase card)
    {
        this.cardData = card;
    }

    // 尝试使用卡牌
    public virtual bool TakeEffect()
    {
        return true;
    }

    // 特效
    public void PlayEffect(Vector2 pos)
    {

    }
}
