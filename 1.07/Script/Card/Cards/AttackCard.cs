using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻击卡
/// </summary>
public class AttackCard : CardDifinition
{
    public int damage;

    public AttackCard(CardBase card) : base(card)
    {
    }

    // public AttackCard(int damage, CardBase cardBase) : base(cardBase)
    // {
    //     this.damage = damage;
    // }
    //一些效果

    public override bool TakeEffect()
    {
        NineGridController controller = NineGridController.Instance;
        if(controller.choosedIndex != -1 && controller.grids[controller.choosedIndex].type == GridType.Enemy)
        {
            return controller.grids[controller.choosedIndex].DoActionForEnemy(this);
        }
        return false;
    }
}
