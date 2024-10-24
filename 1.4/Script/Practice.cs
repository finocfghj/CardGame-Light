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
        ui.ChangeTxt("���Ʒ�Ϊ3��,�ֱ�Ϊ������,ս���ƺͶ�ȡ��");
        StartCoroutine(ShowTxt(4, "�����ƿ�����ɢ�ڰ�,���������ڵ���,������������ʱ���ý�������"));
        StartCoroutine(ShowTxt(10, "�����ƿ��ԶԵ�������˺�,���������˺��Դ��,�����л���"));
        StartCoroutine(ShowTxt(14, "��δ����������ʹ�ù�����ʱ,ֻ�ܷ���һ��������"));
        StartCoroutine(ShowTxt(18, "��ȡ�ƿ��Խ����˵�������Ϊ����,Ҳ���Զ�ʧȥ�����ĵ���ʹ���Ի�ȡ���ǵĹ�����"));
        StartCoroutine(ShowTxt(24, "����,ʹ�����е�����������ս������������"));
        StartCoroutine(ShowTxt(28, "���ֵ��˺�,����������ڵ�������Բ鿴���˵�����������"));
        StartCoroutine(ShowTxt(32, "�Ժ��ص���ʼ����,ף����Ϸ���!"));
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
