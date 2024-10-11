using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Inventory/CardDifinition",menuName ="New Card Definition")]
public class CardBase:ScriptableObject
{
    public Sprite _sprite;
    public float cost;//加费卡的费用是负的
    public string _name;
    public bool canSeek;//是否可以以敌人为对象释放
    public string description;//卡牌描述
}
