using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyUiController : MonoBehaviour
{
    public SpriteRenderer enemySprite;
    public TMP_Text attack;
    public TMP_Text Hp;
    public TMP_Text arm;
    public GameObject hp;
    public TMP_Text feature;
    EnemyStat EnemyStat;

    public void Init(Sprite enemy,EquipmentBase equipment)
    {
        EnemyStat = GetComponentInParent<EnemyStat>();
        enemySprite = transform.Find("enemy").GetComponent<SpriteRenderer>();
        attack = transform.Find("attack").GetComponent<TMP_Text>();
        Hp = transform.Find("hp").GetComponent<TMP_Text>();
        arm = transform.Find("arm").GetComponent<TMP_Text>();
        feature = transform.Find("feature").GetComponent<TMP_Text>();
        enemySprite.sprite = enemy;
        attack.text = EnemyStat.power.ToString();
        Hp.text = EnemyStat.HP.ToString();
        if (equipment != null)
            arm.text = equipment.description;
        else arm.text = "";
        feature.text = EnemyStat.enemy.features;
        hp = transform.Find("hpSlot/HP").gameObject;
        EnemyStat.hpChange += OnHpChange;
    }

    public void OnHpChange()
    {
        Hp.text = EnemyStat.HP.ToString();
        hp.transform.localScale = new Vector3((float)EnemyStat.HP / (float)EnemyStat.enemy.hp, 1, 1);
    }



}
