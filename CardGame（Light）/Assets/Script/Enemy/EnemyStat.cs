using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    //动画等组件
    private int hp;
    public int power;//敌人攻击
    public float lightedTime;

    public int HP
    {
        get { return hp; }
        set
        {
            if (value < 0)
            {
                hp = 0;
                Die();
            }
            else
                hp = value;
        }
    }

    public EnemyStat(int hp, int power)
    {
        this.hp = hp;
        this.power = power;
        lightedTime = 0;
    }

    public System.Action hpChange;//与UI交互,播放受击动画等等
    public System.Action lightChange;

    public void GetDamaged(int damage,AttackCard card)//传入卡牌是为了计算卡牌的附带效果（没写）
    {
        HP = HP - damage;
        hpChange();
    }

    public void GetLighted(LightCard card)
    {
        lightedTime-= card.cost;
        lightChange();
    }

    private void Die()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<AttackCard>(out var attackCard))
        {
            //敌人被选中的特效（血量条预览？）
            attackCard.enemy = this;
        }
        else if(other.gameObject.TryGetComponent<LightCard>(out var otherCard))
        {
            //敌人被选中的特效
            otherCard.enemy = this;
        }
    }


}
