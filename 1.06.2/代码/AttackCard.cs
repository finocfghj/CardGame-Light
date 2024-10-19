using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 攻击卡
/// </summary>
public class AttackCard : CardDifinition, IPointerDownHandler
{
    public int damage;

    // public AttackCard(int damage, CardBase cardBase) : base(cardBase)
    // {
    //     this.damage = damage;
    // }
    //一些效果

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

    // 按下
    public void OnPointerDown(PointerEventData eventData)
    {
        // 显示箭头界面
        UIManager.Instance.ShowUI<LineUI>("LineUI");
        Debug.Log("7777777777777777757893464");
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
                // 设置箭头位置
                UIManager.Instance.GetUI<LineUI>("LineUI").SetEndPos(pos);
                // 进行检测是否在格子中
                // CheckToGrid();
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
        // 如果在格子中，按下鼠标左键，执行相应脚本
        if (Input.GetMouseButtonDown(0))
        {
            // 关闭所有协同程序
            StopAllCoroutines();

            // 鼠标显示
            Cursor.visible = true;
            // 关闭曲线界面
            UIManager.Instance.CloseUI("LineUI");

            if (TakeEffect() == true)
            {
                // 执行逻辑
            }
        }
    }
}
