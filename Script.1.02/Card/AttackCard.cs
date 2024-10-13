using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard:CardDifinition
{
    public int damage;

    public AttackCard(int damage,CardBase cardBase) : base(cardBase)
    {
        this.damage = damage;
    }
    //一些效果


    public override void TakeEffect()
    {
        NineGridController controller = NineGridController.Instance;
        if(controller.choosedIndex != -1 && controller.grids[controller.choosedIndex].type == GridType.Enemy)
        {
            controller.grids[controller.choosedIndex].DoAction();
        }
    }
}
