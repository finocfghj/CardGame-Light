using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// ������
/// </summary>
public class LightCard : CardDifinition
{
    public int length; //���÷�Χ�ı߳�
    public float time; //����ʱ��
    public GameObject spotLight;

    public LightCard(CardBase card) : base(card)
    {
    }


    public override bool TakeEffect()
    {
        NineGridController controller = NineGridController.Instance;
        if (controller.choosedIndex != -1)
        {
            Transform lightPosition = controller.grids[controller.choosedIndex].transform;
            //�������÷�Χ�͸ø����ھŹ����е�λ�ã��������Դ����λ��,�����Ȳ�д
            var newLight = GameObjectCreator.instance.CreateObject(spotLight, lightPosition);
            var newLightScript = newLight.AddComponent<LightController>();
            //newLightScript.Init(һЩ����)
            //�������÷�Χ������շ�Χ��δ������ĸ���
        }

        return true;
    }
}
