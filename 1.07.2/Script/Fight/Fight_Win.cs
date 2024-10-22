using SaveSystemTutorial;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战斗胜利
/// </summary>
public class Fight_Win : FightUnit
{
    public override void Init()
    {
        Debug.Log("Win");
        // UIManager.ShowUI<WinUI>("WinUI");
    }

    public override void OnUpdate()
    {

    }
}
