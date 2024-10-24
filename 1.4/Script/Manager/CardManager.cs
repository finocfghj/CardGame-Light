using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 卡牌管理（战斗时）
/// </summary>
public class CardManager:MonoBehaviour
{
    public static CardManager Instance;

    public Inventory cardList; // 卡堆
    public Inventory usedCardList; // 弃牌堆
    // 存名字，或者卡牌本身object，都行

    private void Awake()
    {
        Instance = this;
    }

    // 初始化战斗卡牌
    public void Init()
    {
        cardList = new Inventory();
        usedCardList = new Inventory();

        // 初始化操作...
        // 比如将玩家的卡牌添加到卡堆
        #region 
        // // 临时集合
        // List<string> tempList = new List<string>();
        // // 将玩家的卡牌存储到临时集合
        // tempList.AddRange(PlayerManager.Instance.cardList);

        // while (tempList.Count > 0)
        // {
        //     // 随机下标
        //     int tempIndex = Random.Range(0, tempList.Count);

        //     // 添加到卡堆
        //     cardList.Add(tempList[tempIndex]);

        //     // 临时集合删除
        //     tempList.RemoveAt(tempIndex);
        // }
        #endregion

        for (int i = 0; i < 2; i++) //六张初始手牌
        {
            AddCard(CardInventory.Instance.GetCardRandomlyFromType(CardType.Attack));
            AddCard(CardInventory.Instance.GetCardRandomlyFromType(CardType.Light));
            AddCard(CardInventory.Instance.GetCardRandomlyFromType(CardType.Rob));
        }
    }

    // 是否有卡
    public bool HasCard()
    {
        return cardList.Slots.Count > 0;
    }

    // 将卡牌加入手牌
    public void AddCard(CardDifinition card)
    {
        cardList.AddCard(card);
    }

    public void AddCardToUsed(CardDifinition card)//打出卡牌后进入弃牌堆
    {
        usedCardList.AddCard(card);
    }
    
    public void RecycleCard()//弃牌堆洗回抽牌堆
    {
        //for (int i = 0; i < usedCardList.Slots.Count; i++)
        //{
        //    CardDifinition card = usedCardList.Slots[i].Card;
        //    cardList.AddCard(card);
        //}
        //usedCardList.DeleteAllCard();
        //cardList.Outoforder();//打乱卡堆
    }

    public void RemoveCard(CardDifinition card)
    {
        cardList.RemoveCard(card);
        AddCardToUsed(card);
        if(cardList.Slots.Count == 0)
        {
            FightManager.Instance.GetPlayerHit(2);
            CardDifinition Card = CardInventory.Instance.GetCardRandomly();
            AddCard(Card);//随机添加一张卡
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(Card);//调用fightui
        }
    }

    public void RemoveAllCard()
    {
        cardList.DeleteAllCard();
    }
}
