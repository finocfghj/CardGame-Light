using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 关卡系统
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int level;

    private void Awake()
    {
        Instance = this;
    }

    public void Init()
    {
        level = 0;
    }

    public void Next()
    {
        level++;
    }
}
