using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// 照明卡
/// </summary>
public class LightCard : CardDifinition
{
    public int power;
    public float time; //作用时间

    public LightCard(CardBase card) : base(card)
    {
    }


    public override bool TakeEffect()
    {
        NineGridController controller = NineGridController.Instance;
        if (controller.choosedIndex != -1)
        {
            Transform lightPosition = controller.grids[controller.choosedIndex].transform;//创建一个点光源
            var newLight = GameObjectCreator.instance.CreateObject(ObjectPool.Instance.spotLight, lightPosition);
            newLight.transform.position = new Vector3(0, 0, 0);
            var newLightScript = newLight.AddComponent<LightController>();//这个script会控制点光源的强度逐渐衰减，并在一定时间后销毁
            newLightScript.Init(0.15f, 10, power, 1);
            //下面根据不同的光照卡强度决定激活的格子
            if(power == 1)
            {
                LightGrid(controller,controller.choosedIndex);
            }
            else if(power == 2)
            {
                LightGrid(controller, controller.choosedIndex);
                if(controller.choosedIndex>2)
                    LightGrid(controller, controller.choosedIndex-3);
                if (controller.choosedIndex < 6)
                    LightGrid(controller, controller.choosedIndex + 3);
                if(controller.choosedIndex % 3 !=0)
                    LightGrid(controller, controller.choosedIndex-1);
                if(controller.choosedIndex %3 != 2)
                    LightGrid(controller, controller.choosedIndex+1);
            }
            else if (power == 3)
            {
                for(int i=0;i<9;i++)
                {
                    LightGrid(controller,i);
                }
            }
        }

        return true;
    }

    //激活对应格子
    private void LightGrid(NineGridController controller,int index)
    {
        if (controller.grids[index].Active)
        {
            controller.grids[index].LightTime = time;
        }
        else
        {
            controller.grids[index].LightGrid(time);
        }
    }
}
