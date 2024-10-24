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
        GameApp.instance.Save();
        // 返回主菜单
        Register("bg/Back").onClick = onBackBtn;
        // 选择奖励
        Register("bg/Next").onClick = onNextBtn;
    }

    private void onBackBtn(GameObject obj, PointerEventData pdata)
    {
        UIManager.Instance.CloseAllUI();
        Destroy(NineGridController.Instance.gameObject);
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

    private void onNextBtn(GameObject obj, PointerEventData pdata)
    {
        NextLevel();
    }

    private void NextLevel()
    {
        // 下一关
        Destroy(NineGridController.Instance.gameObject);
        LevelManager.Instance.Next();
        UIManager.Instance.CloseAllUI();
        FightManager.Instance.ChangeType(FightType.Init);
    }
}
