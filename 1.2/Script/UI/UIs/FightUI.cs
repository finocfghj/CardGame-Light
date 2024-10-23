using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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

        // 文本 & 图像
        // cardCountTxt = transform.Find("...").GetComponent<Text>();
        // noCardCountTxt = transform.Find("...").GetComponent<Text>();
        // powerTxt = 
        // ...

        // 按钮
        // 暂停界面
        Register("bg/Pause").onClick = onPauseBtn;
        // // 点击卡堆
        // Register("bg/CardInventory").onClick = onCheckCardsBtn;
        // // 点击弃牌堆
        // Register("bg/UsedInventory").onClick = oncheckUsedBtn;
        // 消耗血量抽牌
        Register("bg/AddCard").onClick = onAddCardBtn;
        // 加载装备UI
        UIManager.Instance.ShowUI<EquipmentUI>("EquipmentUI"); 
    }

    private void onPauseBtn(GameObject obj, PointerEventData pData)
    {
        // 暂停
        Time.timeScale = 0;

        // 显示界面
        UIManager.Instance.ShowUI<FightPauseUI>("FightPauseUI");
    }

    private void onAddCardBtn(GameObject obj, PointerEventData pData)
    {
        // 扣两滴血
        FightManager.Instance.GetPlayerHit(2);

        // 抽牌
        CardDifinition Card = CardInventory.Instance.GetCardRandomly();
        CardManager.Instance.AddCard(Card);
        CreateCardItem(Card);
    }

    // private void onCheckCardsBtn(GameObject obj, PointerEventData pData)
    // {
    //     // 打卡卡牌仓库界面
    //     // （是否时停？）
    // }

    // private void oncheckUsedBtn(GameObject obj, PointerEventData pData)
    // {
    //     // 打开弃牌仓库界面
    //     // （是否时停？）
    // }

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
    public void CreateCardItem()//根据卡组生成卡牌
    {
        for (int i = 0; i < CardManager.Instance.cardList.Slots.Count; ++ i)
        {
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
    
    public void CreateCardItem(CardDifinition card)//你写的那个
    {
        GameObject obj = Instantiate(Resources.Load("UI/CardItem"), transform) as GameObject;
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(1000, -600);

        // 获得添加的牌是什么牌
        // 然后添加对应的卡牌脚本
        // 我用攻击牌测试

        CardUi item = obj.AddComponent<CardUi>();

        item.Init(card);
        cardList.Add(item);
        UpdateCardItemPos();
    }

    // 更新卡牌位置
    public void UpdateCardItemPos()
    {
        float offset =(float)(600+cardList.Count*100)/ cardList.Count;
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

        // 添加到弃牌堆
        CardManager.Instance.RemoveCard(card.card);

        // 更新使用后的卡牌数量
        //UpdateUsedCardCount();

        // 从集合中删除
        cardList.Remove(card);

        // 刷新卡牌位置
        UpdateCardItemPos();

        // 卡牌移到弃牌堆效果
        card.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1000, -700), 0.25f);

        card.transform.DOScale(0, 0.25f);

        card.enabled = false; // 禁用卡牌逻辑

        Destroy(card.gameObject, 1);
    }
}
