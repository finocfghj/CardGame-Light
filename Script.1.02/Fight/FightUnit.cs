using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战斗单元（战斗状态基类）
/// </summary>
public class FightUnit
{
    public virtual void Init() { } // 初始化
    public virtual void OnUpdate() { } // 每帧执行
}
