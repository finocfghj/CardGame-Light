using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour
{
    PracticeUI ui;
    public void StartPractice()
    {
        PlayerManager.Instance.Init();
        FightManager.Instance.Init();
        FightManager.Instance.ChangeType(FightType.Init);
        NineGridController.Instance.InitForPractice();

        UIManager.Instance.ShowUI<PracticeUI>("PracticeUI");
        ui = UIManager.Instance.GetUI<PracticeUI>("PracticeUI");
        ui.GetComponent<RectTransform>().anchoredPosition = new Vector2(1400 , 0);
        ui.ChangeTxt("手牌分为3种,分别为照明牌,战斗牌和夺取牌");
        StartCoroutine(ShowTxt(4, "照明牌可以驱散黑暗,照亮区域内敌人,照亮奖励区域时会获得奖励卡牌"));
        StartCoroutine(ShowTxt(10, "攻击牌可以对敌人造成伤害,若敌人受伤后仍存活,则会进行还击"));
        StartCoroutine(ShowTxt(14, "对未照亮的区域使用攻击牌时,只能发挥一部分作用"));
        StartCoroutine(ShowTxt(18, "夺取牌可以将敌人的武器化为己有,也可以对失去武器的敌人使用以获取它们的攻击牌"));
        StartCoroutine(ShowTxt(24, "现在,使用手中的照明牌照亮战斗区域的中央吧"));
        StartCoroutine(ShowTxt(28, "发现敌人后,点击敌人所在的区域可以查看敌人的武器与特性"));
        StartCoroutine(ShowTxt(32, "稍后会回到开始界面,祝您游戏愉快!"));
        StartCoroutine(Return());  
        
    }

    IEnumerator ShowTxt(float time,string txt)
    {
        yield return new WaitForSeconds(time);
        ui.ChangeTxt(txt);
    }

    IEnumerator Return()
    {
        yield return new WaitForSeconds(40);
        GetComponent<GameApp>().RestartGame();
    }

}
