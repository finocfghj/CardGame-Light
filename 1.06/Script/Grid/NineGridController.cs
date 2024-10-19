using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class NineGridController : MonoBehaviour
{
    public static NineGridController Instance;

    public Action<int> gridChoosed;

    public List<GridContoller> grids;

    public List<CardBase> cards; //奖励卡的集合

    public EnemyManager enemyManager = EnemyManager.Instance;

    public int choosedIndex;

    public GameObject gridPrefab;

    public GameObject cardSide;
    public GameObject enemySide;
    public GameObject blackSide;

    const float distance=2.3f;

    private void Awake()
    {
        transform.position = Vector3.zero;
        Instance = this;
        cardSide = ObjectPool.Instance.whiteSideCardGrid;
        enemySide = ObjectPool.Instance.whiteSideEnemyGrid;
        blackSide = ObjectPool.Instance.blackSideGrid;
        gridPrefab=ObjectPool.Instance.emptyObject;
    }

    //初始化九宫格之内的内容
    public void Init(int Hard)
    {
        gridChoosed -= OnPointEnter;
        DeleteAllGrids();
        grids = new List<GridContoller>();
        for (int i = 0; i < 9; i ++)
        {
            var newGrid = GameObjectCreator.instance.CreateObject(gridPrefab, transform);

            newGrid.name ="Grid"+i.ToString();

            newGrid.transform.position = new Vector3((i%3-1)*distance,(1-i/3)*distance);

            var newGridScript = newGrid.AddComponent<GridContoller>();

            if (Random.Range(0, 10) < Hard)
                newGridScript.Init(GridType.Card, i, blackSide, cardSide);
            else
                newGridScript.Init(GridType.Enemy, i, blackSide, enemySide);

            grids.Add(newGridScript);
        }
        choosedIndex = -1;
        gridChoosed += OnPointEnter;
    }

    public void OnPointEnter(int index) //网格被选中会上传到这里
    {
        choosedIndex = index;
        if (choosedIndex >= 0)
        {
            //显示预览效果
        }
    }

    private void DeleteAllGrids()
    {
        if (grids == null) return;
        for (int i = 0; i < grids.Count; i++)
        {
            Destroy(grids[i].gameObject);
        }
    }
}
