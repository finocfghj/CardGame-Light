using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

//��Ҫ��ʹ�ÿ���uiʱ�����ݿ��������Ӷ�Ӧ��card����
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

        //��ʼ��ui
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
        // ��ʾ��ͷ����
        UIManager.Instance.ShowUI<LineUI>("LineUI");
        // ���ÿ�ʼ��λ��
        UIManager.Instance.GetUI<LineUI>("LineUI").SetStartPos(transform.GetComponent<RectTransform>().anchoredPosition);
        // �������
        Cursor.visible = false;
        // �ر�����Эͬ����
        StopAllCoroutines();
        // ����������Эͬ����
        StartCoroutine(OnMouseDownRight(eventData));
    }

    IEnumerator OnMouseDownRight(PointerEventData pData)
    {
        while (true)
        {
            // �����������Ҽ� ����ѭ��
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
                // ���ü�ͷλ��
                UIManager.Instance.GetUI<LineUI>("LineUI").SetEndPos(pos);
                // ���м���Ƿ��ڸ�����
                CheckToGrid();
            }

            yield return null;
        }

        // ����ѭ������ʾ���
        Cursor.visible = true;
        // �رռ�ͷ����
        UIManager.Instance.CloseUI("LineUI");
    }

    private void CheckToGrid()
    {
        //����Ƿ��ڸ�����
        if (NineGridController.Instance.choosedIndex == -1) return;
        // ����ڸ����У�������������ִ����Ӧ�ű�
        if (Input.GetMouseButtonDown(0))
        {
            // �ر�����Эͬ����
            StopAllCoroutines();
            // �����ʾ
            Cursor.visible = true;
            // �ر����߽���
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


    //Vector2 initPos; // ��ק��ʼʱ��¼���Ƶ�λ��

    // ��ʼ��ק
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    initPos = transform.GetComponent<RectTransform>().anchoredPosition;
    //}

    //// ��ק��
    //public void OnDrag(PointerEventData eventData)
    //{
    //    Vector2 pos;
    //    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out pos))
    //    {
    //        transform.GetComponent<RectTransform>().anchoredPosition = pos;
    //    }
    //}

    //// ������ק
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
