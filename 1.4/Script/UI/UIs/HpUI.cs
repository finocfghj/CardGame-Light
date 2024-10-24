using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HpUI : UIBase
{
    private TMP_Text hp;
    private Slider hpSlider;

    private void Start()
    {
        hp=transform.Find("hp").GetComponent<TMP_Text>();
        hp.text = PlayerManager.Instance.hp.ToString();
        hpSlider=GetComponentInChildren<Slider>();
        hpSlider.value = 1;
    }

    public void OnHpChanged(float Hp)
    {
        hpSlider.value = Hp/(float)PlayerManager.Instance.hp;
        hp.text=Hp.ToString()+'/'+PlayerManager.Instance.hp.ToString();
    }
}
