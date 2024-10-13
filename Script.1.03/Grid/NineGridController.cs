using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class NineGridController:MonoBehaviour
{
    public static NineGridController Instance;

    public Action<int> gridChoosed;

    public List<GridContoller> grids;

    public List<CardBase> cards;//�������ļ���

    public EnemyManager enemyManager=EnemyManager.Instance;

    public int choosedIndex;

    public GameObject gridPrefab;

    private void Start()
    {
        Instance = this;
    }

    public void Init(int Hard)//��ʼ���Ź���֮�ڵ�����
    {
        gridChoosed -= OnPointEnter;
        grids = new List<GridContoller>();
        for(int i=0;i<9;i++)
        {
            var newGrid=GameObjectCreator.instance.CreateObject(gridPrefab,transform);
            //������������ڵ�λ��
            var newGridScript = newGrid.AddComponent<GridContoller>();
            //������������˻��ǽ�����
            //grids[i].Init(һЩ����);
            grids.Add(newGridScript);
        }
        choosedIndex = -1;
        gridChoosed += OnPointEnter;
    }

    public void OnPointEnter(int index)//����ѡ�л��ϴ�������
    {
        choosedIndex = index;
        if (choosedIndex >= 0)
        {
            //��ʾԤ��Ч��
        }
    }
}
