using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���һЩ�������������ط��ŵ�Ԥ����
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
