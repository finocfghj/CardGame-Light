using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// ������
/// </summary>
public class LightCard : CardDifinition
{
    public int power;
    public float time; //����ʱ��

    public LightCard(CardBase card) : base(card)
    {
    }


    public override bool TakeEffect()
    {
        NineGridController controller = NineGridController.Instance;
        if (controller.choosedIndex != -1)
        {
            Transform lightPosition = controller.grids[controller.choosedIndex].transform;//����һ�����Դ
            var newLight = GameObjectCreator.instance.CreateObject(ObjectPool.Instance.spotLight, lightPosition);
            newLight.transform.position = new Vector3(0, 0, 0);
            var newLightScript = newLight.AddComponent<LightController>();//���script����Ƶ��Դ��ǿ����˥��������һ��ʱ�������
            newLightScript.Init(0.15f, 10, power, 1);
            //������ݲ�ͬ�Ĺ��տ�ǿ�Ⱦ�������ĸ���
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

    //�����Ӧ����
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
