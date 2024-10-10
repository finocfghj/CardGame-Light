using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardUi : MonoBehaviour,IPointerClickHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    private Image image;
    private InventorySlot slot;
    private TMP_Text description;
    private TMP_Text cost;
    private TMP_Text cardName;
    public void Init(InventorySlot slot)
    {
        image = transform.Find("Image").GetComponent<Image>();
        this.slot = slot;
        description=transform.Find("Description").GetComponent<TMP_Text>();
        cost=transform.Find("Cost").GetComponent<TMP_Text>();
        cardName=transform.Find("CardName").GetComponent<TMP_Text>();

        //��ʼ��ui
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
        cost.text = slot.Card.cost.ToString();
        cardName.text = slot.Card.name;
    }

    public void OnStateChange(object sender,InventorySlotStateChangeArgs args)
    {
        UpdateView(args.slot);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        //�Ŵ�Ƭ
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //��¼��ʼλ��
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //������Ч�򷵻�����
    }

    public void OnDrag(PointerEventData eventData)
    {
        //������ק
    }
}
