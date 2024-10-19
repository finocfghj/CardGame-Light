using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

/// <summary>
/// 战斗界面
/// </summary>
public class FightUI : UIBase
{
    // 战斗信息
    private Text cardCountTxt; // 卡牌数量
    private Text usedCardCountTxt; // 弃牌堆数量
    private Text fightTimeTxt; // 游戏时间
    private Text lightTimeTxt; // 光照时间
    private Text hpTxt;
    private Image hpImg;
    public Text LightPowerTxt;
    public Text ArmorPowerTxt;
    public Text WeaponPowerTxt;

    private List<CardUi> cardList; // 卡牌物体

    private void Awake()
    {
        cardList = new List<CardUi>();

        // cardCountTxt = transform.Find("...").GetComponent<Text>();
        // noCardCountTxt = transform.Find("...").GetComponent<Text>();
        // powerTxt = 
        // ...
    }

    private void Start()
    {
        // 更新UI
        // UpdateHp();
        // UpdateFightTime();
        // UpdateCardCount();
        // UpdateUsedCardCount();
    }

    // 更新战斗时间
    private void UpdateFightTime() => fightTimeTxt.text = FightManager.Instance.fightTime.ToString();
    // 更新光照时间
    private void UPdateLightTime() { lightTimeTxt.text = FightManager.Instance.lightedTime.ToString(); }
    // 更新血量显示
    private void UpdateHp()
    {
        hpTxt.text = FightManager.Instance.CurHp + "/" + FightManager.Instance.MaxHp;
        hpImg.fillAmount = (float)FightManager.Instance.CurHp / FightManager.Instance.MaxHp;
    }
    // 更新卡堆数量
    private void UpdateCardCount() => cardCountTxt.text = CardManager.Instance.cardList.Slots.Count.ToString();
    // 更新弃卡堆数量
    private void UpdateUsedCardCount() => usedCardCountTxt.text = CardManager.Instance.usedCardList.Slots.Count.ToString();
    
    // 创建卡牌物体
    public void CreateCardItem()
    {
        for (int i = 0; i < CardManager.Instance.cardList.Slots.Count; ++ i)
        {
            Debug.Log("111111111111111");
            GameObject obj = Instantiate(Resources.Load("UI/CardItem"), transform) as GameObject;
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(1000, -600);

            // 获得添加的牌是什么牌
            // 然后添加对应的卡牌脚本
            // 我用攻击牌测试

            CardUi item = obj.AddComponent<CardUi>();

            item.Init(CardManager.Instance.cardList.GetCard(i));
            cardList.Add(item);
        }
    }

    // 更新卡牌位置
    public void UpdateCardItemPos()
    {
        float offset = 800.0f / cardList.Count;
        Vector2 startPos = new Vector2(-cardList.Count / 2.0f * offset + offset * 0.5f, -700);
        for (int i = 0; i < cardList.Count; ++i)
        {
            cardList[i].GetComponent<RectTransform>().DOAnchorPos(startPos, 0.5f);
            startPos.x = startPos.x + offset;
        }
    }

    // 删除卡牌物体
    public void RemoveCard(CardUi card)
    {
        card.enabled = false; // 禁用卡牌逻辑

        // 添加到弃牌堆
        CardManager.Instance.RemoveCard(card.card);

        // 更新使用后的卡牌数量
        UpdateUsedCardCount();

        // 从集合中删除
        cardList.Remove(card);

        // 刷新卡牌位置
        UpdateCardItemPos();

        // 卡牌移到弃牌堆效果
        card.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1000, -700), 0.25f);

        card.transform.DOScale(0, 0.25f);

        Destroy(card.gameObject, 1);
    }

}
