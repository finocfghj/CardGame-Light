using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 卡牌管理（战斗时）
/// </summary>
public class CardManager
{
    public static CardManager Instance = new CardManager();

    public List<string> cardList; // 卡堆
    public List<string> usedCardList; // 弃牌堆
    // 存名字，或者卡牌本身object，都行

    // 初始化战斗卡牌
    public void Init()
    {
        cardList = new List<string>();
        usedCardList = new List<string>();

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
        // 其他等等...
    }

    // 是否有卡
    public bool HasCard()
    {
        return cardList.Count > 0;
    }

    // 抽卡
    public string DrawCard()
    {
        string id = cardList[cardList.Count - 1];

        cardList.RemoveAt(cardList.Count - 1);

        return id;
    }
}
