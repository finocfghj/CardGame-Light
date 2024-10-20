using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 存放一些不方便在其他地方放的预制体
/// </summary>
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public GameObject emptyObject;
    public GameObject blackSideGrid;
    public GameObject whiteSideCardGrid;
    public GameObject whiteSideEnemyGrid;
    public GameObject spotLight;

    private void Awake()
    {
        Instance = this;
    }
}
