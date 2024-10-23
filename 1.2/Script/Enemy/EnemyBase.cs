using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory/EnemyBase", menuName = "New Enemy Difinition")]
public class EnemyBase : ScriptableObject
{
    public Sprite enemySprite;
    public int hp;
    public int power;
    public string ArmName;//ͨ��equipmentInventory�����ҵ���Ӧ������
    public string features;
    public Sprite featureSprite;
}
