using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 抢夺卡
/// </summary>
public class RobCard : CardDifinition
{
    // public RobCard(CardBase cardBase) : base(cardBase)
    // {

    // }


    public RobCard(CardBase card) : base(card)
    {
    }

    public override bool TakeEffect()
    {
        NineGridController controller = NineGridController.Instance;
        if (controller.choosedIndex != -1 && controller.grids[controller.choosedIndex].type == GridType.Enemy)//再加一点条件
        {
            return controller.grids[controller.choosedIndex].DoActionForEnemy(this);
        }

        return false;
    }
}
