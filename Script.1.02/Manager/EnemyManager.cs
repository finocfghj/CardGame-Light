using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人管理器
/// </summary>
public class EnemyManager
{
    public static EnemyManager Instance = new EnemyManager();

    private List<EnemyStat> enemyList = new List<EnemyStat>(); // 存储战斗中的敌人

    /// <summary>
    /// 加载敌人资源
    /// </summary>
    /// <param name="id">关卡id</param>
    public void LoadRes(string id)
    {
        // 通过id或其他什么获取对应关卡要加载的敌人

        // 从资源路径加载对应的敌人

        // 添加敌人脚本

        // 存储敌人信息

        // 存储到集合
        // enemyList.Add(...);
    }

    // 移除敌人
    public void DeleteEnemy(EnemyStat enemyStat)
    {
        enemyStat.Die();
        enemyList.Remove(enemyStat);

        enemyStat.ClearOne();

        // 是否击杀所有怪物判断胜利
        if (enemyList.Count == 0)
        {
            FightManager.Instance.ChangeType(FightType.Win);
        }
    }

    // 删除所有敌人
    public void DeleteAllEnemy()
    {
        while (enemyList.Count != 0)
        {
            enemyList[0].ClearOne();
            enemyList.RemoveAt(0);
        }
    }

    // 执行活着的怪物的行为
    public IEnumerator DoAllEnemyAction()
    {
        for (int i = 0; i < enemyList.Count; ++i)
        {
            yield return FightManager.Instance.StartCoroutine(enemyList[i].DoAction());
        }

        // 切换到玩家回合
        FightManager.Instance.ChangeType(FightType.Player);
    }
}
