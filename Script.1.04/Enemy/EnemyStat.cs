using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    //动画等组件
    private int hp;
    public int power; //敌人攻击
    public float lightedTime; //疑似不需要
    public EquipmentBase equipment;

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

    public void Init(int hp, int power,EquipmentBase equipment)
    {
        this.hp = hp;
        this.power = power;
        this.equipment = equipment;
        lightedTime = 0;
    }

    public System.Action hpChange; //与UI交互,播放受击动画等等
    public System.Action lightChange;

    public void GetDamaged(AttackCard card) //传入卡牌是为了计算卡牌的附带效果（没写）
    {
        HP = HP - card.damage;
        hpChange();
    }

    public void GetLighted(LightCard card)
    {
        lightedTime-= card.cost;
        lightChange();
    }

    public void Die() { }
    #region //采用格子的检测，不需要敌人自身的检测
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.TryGetComponent<AttackCard>(out var attackCard))
    //    {
    //        //敌人被选中的特效（血量条预览？）
    //        attackCard.enemy = this;
    //    }
    //    else if(other.gameObject.TryGetComponent<LightCard>(out var otherCard))
    //    {
    //        //敌人被选中的特效
    //        if(otherCard.canSeek)//只有可选对象的卡牌才能触发
    //        otherCard.enemy = this;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.TryGetComponent<AttackCard>(out var attackCard))
    //    {
    //        //敌人被选中的特效（血量条预览？）
    //        attackCard.enemy = null;
    //    }
    //    else if (other.gameObject.TryGetComponent<LightCard>(out var otherCard))
    //    {
    //        //敌人被选中的特效
    //        if(otherCard.canSeek)
    //        otherCard.enemy = null;
    //    }
    //}
    #endregion
    // 删除自己
    public void ClearOne()
    {
        Destroy(gameObject, 1);
        // 删除相应的模型、动画、UI等等
    }

    // 敌人受击反馈
    public IEnumerator DoAction()
    {
        // 播放对应的动画

        // 等待一段时间后执行对应的行为
        yield return new WaitForSeconds(0.5f);
        // 例如攻击玩家
        // ...
        // 玩家扣血
        FightManager.Instance.GetPlayerHit(power);
        // ...

        // 等待动画播放完
        yield return new WaitForSeconds(1);

        // 播放待机（或回到之前状态）
    }
}
