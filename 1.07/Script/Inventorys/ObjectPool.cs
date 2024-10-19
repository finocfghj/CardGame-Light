using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour//专业收容各类不知道应该放哪里的预制体
{
    public static ObjectPool Instance;

    public GameObject emptyObject;
    public GameObject blackSideGrid;
    public GameObject whiteSideCardGrid;
    public GameObject whiteSideEnemyGrid;

    private void Awake()
    {
        Instance = this;
    }
}
