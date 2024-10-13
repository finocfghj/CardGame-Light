using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobCard : CardDifinition
{
    public RobCard(CardBase cardBase) : base(cardBase)
    {

    }

    public RobCard() { }

    public override void TakeEffect()
    {
        NineGridController controller = NineGridController.Instance;
        if (controller.choosedIndex != -1 && controller.grids[controller.choosedIndex].type == GridType.Enemy)//再加一点条件
        {
            controller.grids[controller.choosedIndex].DoAction(this);
        }
    }
}
