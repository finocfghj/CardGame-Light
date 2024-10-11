using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战斗初始化
/// </summary>
public class Fight_Init : FightUnit
{
    public override void Init()
    {
        // 初始化数值
        FightManager.Instance.InitOnce();

        // 切换bgm

        // 敌人生成
        // EnemyManager.Instance.DeleteAllEnemy();
        // EnemyManager.Instance.LoadRes(...);

        // 初始化战斗卡牌
        CardManager.Instance.Init();

        // 显示战斗界面
        // UIManager.Instance.ShowUI<FightUI>("FightUI");

        // 切换到玩家回合
        FightManager.Instance.ChangeType(FightType.Player);

        // ...
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
