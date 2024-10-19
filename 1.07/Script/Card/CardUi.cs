using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

//��Ҫ��ʹ�ÿ���uiʱ�����ݿ��������Ӷ�Ӧ��card����
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

        //��ʼ��ui
        UpdateView();
    }

    private void UpdateView()
    {
        description.text = card.description;
        image.sprite = card._sprite;
        cardName.text = card._name;
    }

    Vector2 initPos; // ��ק��ʼʱ��¼���Ƶ�λ��

    // ��ʼ��ק
    public void OnBeginDrag(PointerEventData eventData)
    {
        initPos = transform.GetComponent<RectTransform>().anchoredPosition;
    }

    // ��ק��
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out pos))
        {
            transform.GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }

    // ������ק
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

    // ����뿪
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(3, 0.25f);
        transform.SetSiblingIndex(index);
        transform.Find("BG").GetComponent<Image>().material.SetColor("_lineColor", Color.white);
        transform.Find("BG").GetComponent<Image>().material.SetFloat("_lineWidth", 1);
    }


    // ������


    //private void Start()
    //{
    //    // transform.Find("bg").GetComponent<Image>().sprite = Resources.Load<Sprite>("");
    //    // transform.Find("bg/icon").GetComponent<Image>().sprite = Resources.Load<Sprite>("");
    //    // transform.Find("bg/msgTxt").GetComponent<Text>().text = string.Format("", "");
    //    // transform.Find("bg/nameTxt").GetComponent<Text>().text = "";
    //    // transform.Find("bg/useTxt").GetComponent<Text>().text = "";
    //    // transform.Find("bg/Text").GetComponent<Text>().text = "";

    //    // ����BG������image����߿�
    //    transform.Find("BG").GetComponent<Image>().material = Instantiate(Resources.Load<Material>("Mats/outline"));
    //}
}
