using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard:CardDifinition
{
    public int damage;

    public AttackCard(Sprite sprite, float cost, string name, bool canSeek,int damage,string discription) : base(sprite, cost, name, canSeek,discription)
    {
        this.damage = damage;
    }
    //一些效果

    public override void TakeEffect()
    {
        base.TakeEffect();
    }
}
