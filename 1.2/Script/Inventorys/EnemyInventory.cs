using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyInventory : MonoBehaviour
{
    public static EnemyInventory Instance;

    public List<EnemyBase> enemys;

    private void Awake()
    {
        Instance = this;
    }

    public EnemyBase GetEnemyRandomly()
    {
        return enemys[Random.Range(0, enemys.Count)];
    }

    public EnemyBase GetEnemy(string name)
    {
        return enemys.FirstOrDefault(enemy => enemy.name == name);
    }
}
