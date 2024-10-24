using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 开始界面
/// </summary>
public class LoginUI : UIBase
{
    /*
    这里以LoginUI举个例子，之后添加UI界面时，要先在特定路径添加该UI的预制体
    如LoginUI，在“bg”panel下有两个botton“startBtn”“quitBtn”

    同时需要写一个与该预制体同名的脚本，并继承UIBase，
    其中在Awake函数中调用Register，传入对应的路径获取该UI
    并为该UI的onClick事件添加函数逻辑，之后实现相应的函数
    */

    private void Awake()
    {
        // 开始游戏
        Register("bg/startBtn").onClick = onStartGameBtn;

        // 退出游戏
        Register("bg/quitBtn").onClick = onExitGameBtn;

        Register("bg/practiceBtn").onClick = onPracticeBtn;
    }

    private void onStartGameBtn(GameObject obj, PointerEventData pData)
    {
        // 关闭login界面
        Close();

        // 进入主界面
        // ...

        UIManager.Instance.ShowUI<EquipmentUI>("EquipmentUI");
        FightManager.Instance.Init();
        LevelManager.Instance.Init();
        GameApp.instance.Load();
        FightManager.Instance.ChangeType(FightType.Init);
    }

    private void onExitGameBtn(GameObject obj, PointerEventData pData)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    private void onPracticeBtn(GameObject obj, PointerEventData pData)
    {
        Close ();
        GameApp.instance.StartPractice();
    }
}
