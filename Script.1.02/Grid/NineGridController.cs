using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NineGridController:MonoBehaviour
{
    public static NineGridController Instance;

    public Action<int> gridChoosed;

    public List<GridContoller> grids;

    public List<CardBase> cards;//�������ļ���

    public EnemyManager enemyManager=EnemyManager.Instance;

    public int choosedIndex;

    private void Start()
    {
        Instance = this;
    }

    public void Init(int Hard)//��ʼ���Ź���֮�ڵ�����
    {
        gridChoosed += OnPointEnter;
        grids = new List<GridContoller>();
        for(int i=0;i<9;i++)
        {
            grids.Add(new GridContoller());
            //������������˻��ǽ�����
            //������������ڵ�λ��
            //grids[i].Init(һЩ����);
        }
        choosedIndex = -1;
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
