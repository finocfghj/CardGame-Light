using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战斗失败
/// </summary>
public class Fight_Lose : FightUnit
{
    public override void Init()
    {
        UIManager.Instance.ShowUI<DeadUI>("DeadUI");
    }

    public override void OnUpdate()
    {

    }
}
