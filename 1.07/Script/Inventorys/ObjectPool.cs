using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour//רҵ���ݸ��಻֪��Ӧ�÷������Ԥ����
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
