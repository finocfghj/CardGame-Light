using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    //动画等组件
    [SerializeField]private int hp;
    public int power; //敌人攻击
    public EquipmentBase equipment;
    public bool isDie;
    public EnemyBase enemy;

    public int HP
    {
        get { return hp; }
        set
        {
            if (value <= 0)
            {
                hp = 0;
                Die();
            }
            else
                hp = value;
        }
    }

    public void Init(EnemyBase enemy)
    {
        this.enemy = enemy;
        hp=enemy.hp+LevelManager.Instance.level*2;
        power=enemy.power+LevelManager.Instance.level*2;
        equipment = EquipmentInventory.Instance.GetEquipment(enemy.ArmName);
        isDie = false;
        EnemyUiController newUI = transform.Find("EnemySide(Clone)").AddComponent<EnemyUiController>();
        if (equipment != null)
        {
            newUI.Init(enemy.enemySprite, equipment);
        }
        else
        {
            newUI.Init(enemy.enemySprite,null);
        }
    }

    public System.Action hpChange; //与UI交互,播放受击动画等等

    public void GetDamaged(AttackCard card , bool isReduction = false) //传入卡牌是为了计算卡牌的附带效果（没写）
    {
        if (enemy.ArmName == "双刀")
            card.damage -= 2;
        if (isReduction)
        {
            HP = HP - PlayerManager.Instance.DoDamage(card.damage) / 2;
        }
        else
            HP = HP - PlayerManager.Instance.DoDamage(card.damage);
        hpChange();
    }

    public void Die() //杀敌抽2
    {
        CardDifinition card = CardInventory.Instance.GetCardRandomly();
        CardManager.Instance.AddCard(card);//随机添加一张卡
        CardDifinition _card = CardInventory.Instance.GetCardRandomly();
        CardManager.Instance.AddCard(_card);//随机添加一张卡
        UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(card);//调用fightui
        UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(_card);//调用fightui
        isDie = true;

        if(EnemyManager.Instance.CheckAllEnemy())//检查是否击败所有敌人
        {
            FightManager.Instance.ChangeType(FightType.Win);
        }
    }
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
        if (equipment != null)//有武器会反击
        {
            // 等待一段时间后执行对应的行为
            yield return new WaitForSeconds(0.1f);
            // 例如攻击玩家
            // ...
            // 玩家扣血
            if(equipment &&  equipment.EquipmentName == "棍棒")
            FightManager.Instance.GetPlayerHit(power+2);
            else if(equipment && equipment.EquipmentName == "宝剑"){
                FightManager.Instance.GetPlayerHit(power + 4);
            }
            else if(equipment && equipment.EquipmentName == "双刀")
            {
                FightManager.Instance.GetPlayerHit(power + 6);
            }
            else
            {
                FightManager.Instance.GetPlayerHit(power);
            }
            // ...

            // 等待动画播放完
            yield return new WaitForSeconds(1);

            // 播放待机（或回到之前状态）
        }
    }
}
