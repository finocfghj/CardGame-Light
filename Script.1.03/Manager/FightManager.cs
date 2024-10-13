using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

// 战斗状态枚举
public enum FightType
{
    None,
    Init, // 初始化
    Player, // 玩家回合
    Enemy, // 敌人回合
    Win, // 胜利
    Lose // 失败
}

/// <summary>
/// 战斗系统
/// </summary>
public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    public FightUnit fightUnit; // 战斗单元



    // 战斗数据
    // 如血量，能量，光照信息，时间等
    // public int MaxHp; // 最大血量
    // public int CurHp; // 当前血量
    // public int MaxPowerCount; // 最大能量
    // public int CurPowerCount; // 当前能量
    // public float fightTime; // 对局时间
    // public float lightedTime; // 照明时间
    // public string lightColor; // 其他信息，如照明颜色等

    // 初始化
    public void Init()
    {
        // 初始化战斗信息
        // MaxHp = 10;
        // CurHp = 10;
        // ...
    }

    // 单局初始化
    public void InitOnce()
    {
        // CurHp = MaxHp;
        // CurPowerCount = MaxPowerCount;
        // ...
    }

    private void Awake()
    {
        Instance = this;
    }

    // 切换战斗类型
    public void ChangeType(FightType type)
    {
        switch (type)
        {
            case FightType.None:
                break;
            case FightType.Init:
                fightUnit = new Fight_Init();
                break;
            case FightType.Player:
                fightUnit = new Fight_PlayerTurn();
                break;
            case FightType.Enemy:
                fightUnit = new Fight_EnemyTurn();
                break;
            case FightType.Win:
                fightUnit = new Fight_Win();
                break;
            case FightType.Lose:
                fightUnit = new Fight_Lose();
                break;
        }
        fightUnit.Init(); // 初始化
    }

    // 玩家受伤逻辑
    public void GetPlayerHit(int hit)
    {
        // 扣血
        // 如果死了切换到游戏失败状态
        ChangeType(FightType.Lose);

        // 更新界面

        // ...
    }

    private void Update()
    {
        if (fightUnit != null)
        {
            fightUnit.OnUpdate();
        }
    }
}
