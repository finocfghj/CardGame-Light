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
        Debug.Log("Lose");
        // UIManager.ShowUI<LoseUI>("LoseUI");
    }

    public override void OnUpdate()
    {

    }
}
