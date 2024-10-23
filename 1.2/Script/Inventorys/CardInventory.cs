using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 全部的卡牌都在这里，实现了根据类型获得卡牌和随机获得卡牌的方法
/// </summary>
public class CardInventory : MonoBehaviour
{
    public static CardInventory Instance;

    [SerializeField] List<CardBase> cards;

    public Inventory AttackCard;
    public Inventory LightCard;
    public Inventory RobCard;

    private void Awake()
    {
        Instance = this;

        AttackCard = new Inventory();
        LightCard = new Inventory();
        RobCard = new Inventory();

        foreach (var card in cards)
        {
            var newCard = new CardDifinition(card);
            
            if (card.type == CardType.Attack)
            {
                AttackCard.AddCard(newCard);
            }
            else if (card.type == CardType.Light)
            {
                LightCard.AddCard(newCard);
            }
            else
            {
                RobCard.AddCard(newCard);
            }
        }
    }

    public Inventory GetAllCardForType(CardType type)
    {
        if (type == CardType.Attack)
            return AttackCard;
        else if (type == CardType.Light)
            return LightCard;
        return RobCard;
    }

    public CardDifinition GetCardRandomlyFromType(CardType type)
    {
        if(type == CardType.Attack)
        {
            return AttackCard.GetCardWithOutDel();
        }
        else if(type == CardType.Light)
        {
            return LightCard.GetCardWithOutDel();
        }
        else
            return RobCard.GetCardWithOutDel();
    }

    public CardDifinition GetCardRandomly()
    {
        int index=Random.Range(0, 3);
        if (index == 0) return AttackCard.GetCardWithOutDel();
        else if (index == 1) return LightCard.GetCardWithOutDel();
        else return RobCard.GetCardWithOutDel();
    }
}
