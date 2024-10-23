using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUiController : MonoBehaviour
{
    public SpriteRenderer enemySprite;
    public SpriteRenderer featureSprite;
    public SpriteRenderer ArmSprite;
    public GameObject hp;
    EnemyStat EnemyStat;

    public void Init(Sprite enemy,Sprite feature,Sprite arm)
    {
        EnemyStat = GetComponentInParent<EnemyStat>();
        enemySprite = transform.Find("enemy").GetComponent<SpriteRenderer>();
        featureSprite = transform.Find("feature").GetComponent <SpriteRenderer>();
        ArmSprite = transform.Find("arm").GetComponent<SpriteRenderer>();
        enemySprite.sprite = enemy;
        featureSprite.sprite = feature;
        ArmSprite.sprite = arm;
        hp = transform.Find("hpSlot/HP").gameObject;
        EnemyStat.hpChange += OnHpChange;
    }

    public void OnHpChange()
    {
        hp.transform.localScale = new Vector3((float)EnemyStat.HP / (float)EnemyStat.enemy.hp, 1, 1);
    }



}
