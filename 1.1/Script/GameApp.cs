using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : MonoBehaviour
{
    void Start()
    {
        // 初始化xxx

        // 初始化角色信息
        // 之后可能有调存档等的操作
        PlayerManager.Instance.Init();

        // 显示登录界面
        //UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        // 播放音乐...

        // 测试用

        FightManager.Instance.Init();
        FightManager.Instance.ChangeType(FightType.Init);
    }
}
