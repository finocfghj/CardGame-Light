using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 玩家死亡，结算界面
/// </summary>
public class DeadUI : UIBase
{
    private void Awake()
    {
        // 返回主菜单
        Register("bg/Back").onClick = onBackbtn;
    }

    private void onBackbtn(GameObject obj, PointerEventData pdata)
    {
        UIManager.Instance.CloseAllUI();
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
    }
}
