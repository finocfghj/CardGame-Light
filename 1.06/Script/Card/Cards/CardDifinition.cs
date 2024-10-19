using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class CardDifinition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // 卡牌信息
    CardBase cardData;
    public Sprite _sprite => cardData._sprite;
    public string _name => cardData._name;
    public bool canSeek => cardData.canSeek;
    public string description => cardData.description;
    public CardType type => cardData.type;
    public int targetNumber => cardData.targetNumber;

    // public CardDifinition(Sprite sprite, string name, bool canSeek, string description, CardType type)
    // {
    //     card._sprite = sprite;
    //     card.name = name;
    //     card.canSeek = canSeek;
    //     card.description = description;
    //     card.type = type;
    // }

    // public CardDifinition(CardBase card)
    // {
    //     this.card = card;
    // }

    // public CardDifinition() { }

    public void Init(CardBase card)
    {
        cardData = card;
    }

    private int index;

    // 鼠标进入
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

    private void Start()
    {
        // transform.Find("bg").GetComponent<Image>().sprite = Resources.Load<Sprite>("");
        // transform.Find("bg/icon").GetComponent<Image>().sprite = Resources.Load<Sprite>("");
        // transform.Find("bg/msgTxt").GetComponent<Text>().text = string.Format("", "");
        // transform.Find("bg/nameTxt").GetComponent<Text>().text = "";
        // transform.Find("bg/useTxt").GetComponent<Text>().text = "";
        // transform.Find("bg/Text").GetComponent<Text>().text = "";

        // 配置BG背景和image的外边框
        transform.Find("BG").GetComponent<Image>().material = Instantiate(Resources.Load<Material>("Mats/outline"));
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
