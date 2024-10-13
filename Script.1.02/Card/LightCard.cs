using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightCard : CardDifinition
{
    public int length;//作用范围的边长
    public float time;//作用时间
    public GameObject spotLight;

    public LightCard(CardBase cardBase, int length, float time) : base(cardBase)
    {
        this.length = length;
        this.time = time;
    }

    public override void TakeEffect()
    {
        NineGridController controller = NineGridController.Instance;
        if (controller.choosedIndex != -1)
        {
            Transform lightPosition = controller.grids[controller.choosedIndex].transform;
            //根据作用范围和该格子在九宫格中的位置，计算出光源所在位置,这里先不写
            var newLight = GameObjectCreator.instance.CreateObject(spotLight, lightPosition);
            var newLightScript = newLight.AddComponent<LightController>();
            //newLightScript.Init(一些参数)
            //根据作用范围激活光照范围下未被激活的格子
        }
    }
}
