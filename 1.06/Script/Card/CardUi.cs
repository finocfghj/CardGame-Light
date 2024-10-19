using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

//��Ҫ��ʹ�ÿ���uiʱ�����ݿ��������Ӷ�Ӧ��card����
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
        cardName.text = slot.Card._name;
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
        if(!slot.Card.TakeEffect())//�������������Ч�ĺ���������ֵ��ʾ�ò����Ƿ�Ϸ�
        {
            //��������
        }
    }

    public void OnDrag(PointerEventData eventData)//���ģ�����ǻ�ȡ����λ�ã�Ȼ���ƶ���ȥ
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out pos))
        {
            transform.GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }
}
