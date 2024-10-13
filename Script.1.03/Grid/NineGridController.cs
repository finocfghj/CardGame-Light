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

    public List<CardBase> cards;//奖励卡的集合

    public EnemyManager enemyManager=EnemyManager.Instance;

    public int choosedIndex;

    public GameObject gridPrefab;

    private void Start()
    {
        Instance = this;
    }

    public void Init(int Hard)//初始化九宫格之内的内容
    {
        gridChoosed -= OnPointEnter;
        grids = new List<GridContoller>();
        for(int i=0;i<9;i++)
        {
            var newGrid=GameObjectCreator.instance.CreateObject(gridPrefab,transform);
            //计算出格子所在的位置
            var newGridScript = newGrid.AddComponent<GridContoller>();
            //随机数决定敌人还是奖励牌
            //grids[i].Init(一些参数);
            grids.Add(newGridScript);
        }
        choosedIndex = -1;
        gridChoosed += OnPointEnter;
    }

    public void OnPointEnter(int index)//网格被选中会上传到这里
    {
        choosedIndex = index;
        if (choosedIndex >= 0)
        {
            //显示预览效果
        }
    }
}
