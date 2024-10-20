using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
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
        FightManager.Instance.fightGrids= GameObjectCreator.instance.CreateObject(ObjectPool.Instance.emptyObject);
        FightManager.Instance.fightGrids.name = "Nine Grid";
        NineGridController newGridController = FightManager.Instance.fightGrids.AddComponent<NineGridController>();
        newGridController.Init(5);

        // 初始化战斗卡牌
        CardManager.Instance.Init();

        // 显示战斗界面
        UIManager.Instance.ShowUI<FightUI>("FightUI");//这里需要加载出手牌的UI
        UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem();
        UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();

        // 切换到战斗进行
        FightManager.Instance.ChangeType(FightType.Fighting);

        // ...
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
