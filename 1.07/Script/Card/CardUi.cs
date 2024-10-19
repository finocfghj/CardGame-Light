using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

//需要在使用卡牌ui时，根据卡的类别添加对应的card子类
public class CardUi : UIBase, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]private Image image;
    [SerializeField]public CardDifinition card;
    [SerializeField]private TMP_Text description;
    [SerializeField]private TMP_Text cardName;
    private int index;

    public void Init(CardDifinition card)
    {
        this.card = card;
        image = transform.Find("BG/Image").GetComponent<Image>();
        description= transform.Find("BG").transform.Find("Description").GetComponent<TMP_Text>();
        cardName= transform.Find("BG").transform.Find("CardName").GetComponent<TMP_Text>();
        transform.Find("BG").GetComponent<Image>().material = Instantiate(Resources.Load<Material>("Mats/outline"));

        //初始化ui
        UpdateView();
    }

    private void UpdateView()
    {
        description.text = card.description;
        image.sprite = card._sprite;
        cardName.text = card._name;
    }

    Vector2 initPos; // 拖拽开始时记录卡牌的位置

    // 开始拖拽
    public void OnBeginDrag(PointerEventData eventData)
    {
        initPos = transform.GetComponent<RectTransform>().anchoredPosition;
    }

    // 拖拽中
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out pos))
        {
            transform.GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }

    // 结束拖拽
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.GetComponent<RectTransform>().anchoredPosition = initPos;
        transform.SetSiblingIndex(index);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(4.5f, 0.25f);
        index = transform.GetSiblingIndex();
        transform.SetAsLastSibling();

        transform.Find("BG").GetComponent<Image>().material.SetColor("_lineColor", Color.yellow);
        transform.Find("BG").GetComponent<Image>().material.SetFloat("_lineWidth", 10);
    }

    // 鼠标离开
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(3, 0.25f);
        transform.SetSiblingIndex(index);
        transform.Find("BG").GetComponent<Image>().material.SetColor("_lineColor", Color.white);
        transform.Find("BG").GetComponent<Image>().material.SetFloat("_lineWidth", 1);
    }


    // 鼠标进入


    //private void Start()
    //{
    //    // transform.Find("bg").GetComponent<Image>().sprite = Resources.Load<Sprite>("");
    //    // transform.Find("bg/icon").GetComponent<Image>().sprite = Resources.Load<Sprite>("");
    //    // transform.Find("bg/msgTxt").GetComponent<Text>().text = string.Format("", "");
    //    // transform.Find("bg/nameTxt").GetComponent<Text>().text = "";
    //    // transform.Find("bg/useTxt").GetComponent<Text>().text = "";
    //    // transform.Find("bg/Text").GetComponent<Text>().text = "";

    //    // 配置BG背景和image的外边框
    //    transform.Find("BG").GetComponent<Image>().material = Instantiate(Resources.Load<Material>("Mats/outline"));
    //}
}
