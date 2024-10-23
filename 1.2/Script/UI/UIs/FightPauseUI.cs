using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FightPauseUI : UIBase
{
    private void Awake()
    {
        // 继续
        Register("bg/Continue").onClick = onContinueBtn;
        // 退出
        Register("bg/FightEnd").onClick = onFightEndBtn;
        // 其他设置...
        // ...
    }

    private void onFightEndBtn(GameObject obj, PointerEventData pdata)
    {
        UIManager.Instance.CloseAllUI();
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
    }

    private void onContinueBtn(GameObject obj, PointerEventData pdata)
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
