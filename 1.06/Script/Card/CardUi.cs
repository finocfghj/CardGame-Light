using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

//需要在使用卡牌ui时，根据卡的类别添加对应的card子类
public class CardUi : UIBase,IPointerClickHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    private Image image;
    private InventorySlot slot;
    private TMP_Text description;
    private TMP_Text cardName;

    
    public void Init(InventorySlot slot)
    {
        image = transform.Find("Image").GetComponent<Image>();
        this.slot = slot;
        description=transform.Find("Description").GetComponent<TMP_Text>();
        cardName=transform.Find("CardName").GetComponent<TMP_Text>();

        //初始化ui
        AssignSlot();
        UpdateView(slot);
    }

    private void AssignSlot()
    {
        slot.StateChanged += OnStateChange;
    }

    private void UpdateView(InventorySlot slot)
    {
        image.sprite = slot.Card._sprite;
        description.text = slot.Card.description;
        cardName.text = slot.Card._name;
    }

    public void OnStateChange(object sender,InventorySlotStateChangeArgs args)
    {
        UpdateView(args.slot);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        //放大卡片
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //记录初始位置
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //卡牌生效或返回手牌
        if(!slot.Card.TakeEffect())//这个函数就是生效的函数，返回值表示该操作是否合法
        {
            //返回手牌
        }
    }

    public void OnDrag(PointerEventData eventData)//抄的，大概是获取鼠标的位置，然后移动过去
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out pos))
        {
            transform.GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }
}
