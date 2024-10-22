using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

//需要在使用卡牌ui时，根据卡的类别添加对应的card子类
public class CardUi : UIBase, IPointerDownHandler ,IPointerEnterHandler, IPointerExitHandler//, IBeginDragHandler, IDragHandler, IEndDragHandler
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

    public void OnPointerDown(PointerEventData eventData)
    {
        // 显示箭头界面
        UIManager.Instance.ShowUI<LineUI>("LineUI");
        // 设置开始点位置
        UIManager.Instance.GetUI<LineUI>("LineUI").SetStartPos(transform.GetComponent<RectTransform>().anchoredPosition);
        // 隐藏鼠标
        Cursor.visible = false;
        // 关闭所有协同程序
        StopAllCoroutines();
        // 启动鼠标操作协同程序
        StartCoroutine(OnMouseDownRight(eventData));
    }

    IEnumerator OnMouseDownRight(PointerEventData pData)
    {
        while (true)
        {
            // 如果按下鼠标右键 跳出循环
            if (Input.GetMouseButton(1))
            {
                break;
            }

            Vector2 pos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform.parent.GetComponent<RectTransform>(),
                pData.position,
                pData.pressEventCamera,
                out pos))
            {
                pos-=new Vector2(0, 10);
                // 设置箭头位置
                UIManager.Instance.GetUI<LineUI>("LineUI").SetEndPos(pos);
                // 进行检测是否在格子中
                CheckToGrid();
            }

            yield return null;
        }

        // 跳出循环后显示鼠标
        Cursor.visible = true;
        // 关闭箭头界面
        UIManager.Instance.CloseUI("LineUI");
    }

    private void CheckToGrid()
    {
        //检查是否在格子中
        if (NineGridController.Instance.choosedIndex == -1) return;
        // 如果在格子中，按下鼠标左键，执行相应脚本
        if (Input.GetMouseButtonDown(0))
        {
            // 关闭所有协同程序
            StopAllCoroutines();
            // 鼠标显示
            Cursor.visible = true;
            // 关闭曲线界面
            UIManager.Instance.CloseUI("LineUI");

            if (card.type == CardType.Attack)
            {
                AttackCard _card = new AttackCard(card.cardData);
                _card.damage = card.targetNumber;
        
                if(_card.TakeEffect())
                {
                    UIManager.Instance.GetUI<FightUI>("FightUI").RemoveCard(this);
                }
            }
            if (card.type == CardType.Light)
            {
                LightCard _card = new LightCard(card.cardData);
                _card.power = card.targetNumber;
                _card.time = PlayerManager.Instance.LightPower;
                if (_card.TakeEffect())
                {
                    UIManager.Instance.GetUI<FightUI>("FightUI").RemoveCard(this);
                }
            }
            if (card.type == CardType.Rob)
            {
                RobCard _card = new RobCard(card.cardData);
                if (_card.TakeEffect())
                {
                    UIManager.Instance.GetUI<FightUI>("FightUI").RemoveCard(this);
                }
            }
            
        }
    }


    //Vector2 initPos; // 拖拽开始时记录卡牌的位置

    // 开始拖拽
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    initPos = transform.GetComponent<RectTransform>().anchoredPosition;
    //}

    //// 拖拽中
    //public void OnDrag(PointerEventData eventData)
    //{
    //    Vector2 pos;
    //    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out pos))
    //    {
    //        transform.GetComponent<RectTransform>().anchoredPosition = pos;
    //    }
    //}

    //// 结束拖拽
    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    transform.GetComponent<RectTransform>().anchoredPosition = initPos;
    //    transform.SetSiblingIndex(index);
    //}


    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(4f, 0.25f);
        index = transform.GetSiblingIndex();
        transform.SetAsLastSibling();

        transform.Find("BG").GetComponent<Image>().material.SetColor("_lineColor", Color.yellow);
        transform.Find("BG").GetComponent<Image>().material.SetFloat("_lineWidth", 5);
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
