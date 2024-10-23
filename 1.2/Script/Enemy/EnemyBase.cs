using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory/EnemyBase", menuName = "New Enemy Difinition")]
public class EnemyBase : ScriptableObject
{
    public Sprite enemySprite;
    public int hp;
    public int power;
    public string ArmName;//通过equipmentInventory可以找到对应的武器
    public string features;
    public Sprite featureSprite;
}
