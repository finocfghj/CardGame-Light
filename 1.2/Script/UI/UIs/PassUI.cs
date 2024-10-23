using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 奖励选择
/// </summary>
public class PassUI : UIBase
{
    private void Awake()
    {
        // 返回主菜单
        Register("bg/Back").onClick = onBackBtn;
        // 选择奖励
        Register("bg/Award1").onClick = onAword1Btn;
        Register("bg/Award2").onClick = onAword2Btn;
        Register("bg/Award3").onClick = onAword3Btn;
    }

    private void onBackBtn(GameObject obj, PointerEventData pdata)
    {
        UIManager.Instance.CloseAllUI();
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
    }

    private void onAword1Btn(GameObject obj, PointerEventData pdata)
    {
        // 奖励

        // 下一关
        NextLevel();
    }

    private void onAword2Btn(GameObject obj, PointerEventData pdata)
    {
        // 奖励

        // 下一关
        NextLevel();
    }

    private void onAword3Btn(GameObject obj, PointerEventData pdata)
    {
        // 奖励

        // 下一关
        NextLevel();
    }

    private void NextLevel()
    {
        // 下一关
        LevelManager.Instance.Next();
        FightManager.Instance.ChangeType(FightType.Init);
    }
}
