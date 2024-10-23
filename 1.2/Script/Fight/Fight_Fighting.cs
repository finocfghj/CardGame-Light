using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战斗进行
/// </summary>
public class Fight_Fighting : FightUnit
{
    public override void Init()
    {
        // 显示战斗界面
        UIManager.Instance.ShowUI<FightUI>("FightUI");//这里需要加载出手牌的UI
        UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem();
        UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();
    }

    public override void OnUpdate() { }
}
