using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
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

    public const float distance=1.8f;

    private void Awake()
    {
        Instance = this;
        cardSide = ObjectPool.Instance.whiteSideCardGrid;
        enemySide = ObjectPool.Instance.whiteSideEnemyGrid;
        blackSide = ObjectPool.Instance.blackSideGrid;
        gridPrefab=ObjectPool.Instance.emptyObject;
    }

    //初始化九宫格之内的内容
    public void Init(int Hard)//进入或重新开始关卡时调用，hard越大，敌人越多，奖励牌越少
    {
        int enemyCount=0;
        transform.position = new Vector3(0, 0.7f, 0);
        gridChoosed -= OnPointEnter;
        DeleteAllGrids();
        grids = new List<GridContoller>();
        for (int i = 0; i < 9; i ++)
        {
            var newGrid = GameObjectCreator.instance.CreateObject(gridPrefab, transform);

            newGrid.name ="Grid"+i.ToString();

            newGrid.transform.position =transform.position+ new Vector3((i%3-1)*(distance-0.2f),(1-i/3)*(distance+.2f));

            var newGridScript = newGrid.AddComponent<GridContoller>();

            if (Random.Range(0, 10) >= Hard && enemyCount<6)
            {
                newGridScript.Init(GridType.Enemy, i, blackSide, enemySide);
                enemyCount++;
            }
            else
                newGridScript.Init(GridType.Card, i, blackSide, cardSide);
            grids.Add(newGridScript);
        }
        choosedIndex = -1;
        gridChoosed += OnPointEnter;
    }

    public void InitForPractice()
    {
        transform.position = new Vector3(0, 0.7f, 0);
        gridChoosed -= OnPointEnter;
        DeleteAllGrids();
        grids = new List<GridContoller>();
        for (int i = 0; i < 9; i++)
        {
            var newGrid = GameObjectCreator.instance.CreateObject(gridPrefab, transform);

            newGrid.name = "Grid" + i.ToString();

            newGrid.transform.position = transform.position + new Vector3((i % 3 - 1) * (distance - 0.2f), (1 - i / 3) * (distance + .2f));

            var newGridScript = newGrid.AddComponent<GridContoller>();

            if (i%3==1 || i/3==1)
            {
                newGridScript.Init(GridType.Enemy, i, blackSide, enemySide);
            }
            else
                newGridScript.Init(GridType.Card, i, blackSide, cardSide);
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

    private void DeleteAllGrids()//退出关卡时可以使用
    {
        if (grids == null) return;
        for (int i = 0; i < grids.Count; i++)
        {
            Destroy(grids[i].gameObject);
        }
    }
}
