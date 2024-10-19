using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// ������
/// </summary>
public class AttackCard : CardDifinition, IPointerDownHandler
{
    public int damage;

    // public AttackCard(int damage, CardBase cardBase) : base(cardBase)
    // {
    //     this.damage = damage;
    // }
    //һЩЧ��

    // public override bool TakeEffect()
    // {
    //     NineGridController controller = NineGridController.Instance;
    //     if (controller.choosedIndex != -1 && controller.grids[controller.choosedIndex].type == GridType.Enemy)
    //     {
    //         return controller.grids[controller.choosedIndex].DoActionForEnemy(this);
    //     }
    //     return false;
    // }

    public override void OnBeginDrag(PointerEventData eventData)
    {

    }

    public override void OnDrag(PointerEventData eventData)
    {

    }

    public override void OnEndDrag(PointerEventData eventData)
    {

    }

    // ����
    public void OnPointerDown(PointerEventData eventData)
    {
        // ��ʾ��ͷ����
        UIManager.Instance.ShowUI<LineUI>("LineUI");
        Debug.Log("7777777777777777757893464");
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
                // ���ü�ͷλ��
                UIManager.Instance.GetUI<LineUI>("LineUI").SetEndPos(pos);
                // ���м���Ƿ��ڸ�����
                // CheckToGrid();
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
        // ����ڸ����У�������������ִ����Ӧ�ű�
        if (Input.GetMouseButtonDown(0))
        {
            // �ر�����Эͬ����
            StopAllCoroutines();

            // �����ʾ
            Cursor.visible = true;
            // �ر����߽���
            UIManager.Instance.CloseUI("LineUI");

            if (TakeEffect() == true)
            {
                // ִ���߼�
            }
        }
    }
}
