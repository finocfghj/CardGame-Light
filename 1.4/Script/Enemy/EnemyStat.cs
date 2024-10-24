using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    //���������
    [SerializeField]private int hp;
    public int power; //���˹���
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

    public System.Action hpChange; //��UI����,�����ܻ������ȵ�

    public void GetDamaged(AttackCard card , bool isReduction = false) //���뿨����Ϊ�˼��㿨�Ƶĸ���Ч����ûд��
    {
        if (enemy.ArmName == "˫��")
            card.damage -= 2;
        if (isReduction)
        {
            HP = HP - PlayerManager.Instance.DoDamage(card.damage) / 2;
        }
        else
            HP = HP - PlayerManager.Instance.DoDamage(card.damage);
        hpChange();
    }

    public void Die() //ɱ�г�2
    {
        CardDifinition card = CardInventory.Instance.GetCardRandomly();
        CardManager.Instance.AddCard(card);//������һ�ſ�
        CardDifinition _card = CardInventory.Instance.GetCardRandomly();
        CardManager.Instance.AddCard(_card);//������һ�ſ�
        UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(card);//����fightui
        UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(_card);//����fightui
        isDie = true;

        if(EnemyManager.Instance.CheckAllEnemy())//����Ƿ�������е���
        {
            FightManager.Instance.ChangeType(FightType.Win);
        }
    }
    #region //���ø��ӵļ�⣬����Ҫ��������ļ��
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.TryGetComponent<AttackCard>(out var attackCard))
    //    {
    //        //���˱�ѡ�е���Ч��Ѫ����Ԥ������
    //        attackCard.enemy = this;
    //    }
    //    else if(other.gameObject.TryGetComponent<LightCard>(out var otherCard))
    //    {
    //        //���˱�ѡ�е���Ч
    //        if(otherCard.canSeek)//ֻ�п�ѡ����Ŀ��Ʋ��ܴ���
    //        otherCard.enemy = this;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.TryGetComponent<AttackCard>(out var attackCard))
    //    {
    //        //���˱�ѡ�е���Ч��Ѫ����Ԥ������
    //        attackCard.enemy = null;
    //    }
    //    else if (other.gameObject.TryGetComponent<LightCard>(out var otherCard))
    //    {
    //        //���˱�ѡ�е���Ч
    //        if(otherCard.canSeek)
    //        otherCard.enemy = null;
    //    }
    //}
    #endregion
    // ɾ���Լ�
    public void ClearOne()
    {
        Destroy(gameObject, 1);
        // ɾ����Ӧ��ģ�͡�������UI�ȵ�
    }

    // �����ܻ�����
    public IEnumerator DoAction()
    {
        // ���Ŷ�Ӧ�Ķ���
        if (equipment != null)//�������ᷴ��
        {
            // �ȴ�һ��ʱ���ִ�ж�Ӧ����Ϊ
            yield return new WaitForSeconds(0.1f);
            // ���繥�����
            // ...
            // ��ҿ�Ѫ
            if(equipment &&  equipment.EquipmentName == "����")
            FightManager.Instance.GetPlayerHit(power+2);
            else if(equipment && equipment.EquipmentName == "����"){
                FightManager.Instance.GetPlayerHit(power + 4);
            }
            else if(equipment && equipment.EquipmentName == "˫��")
            {
                FightManager.Instance.GetPlayerHit(power + 6);
            }
            else
            {
                FightManager.Instance.GetPlayerHit(power);
            }
            // ...

            // �ȴ�����������
            yield return new WaitForSeconds(1);

            // ���Ŵ�������ص�֮ǰ״̬��
        }
    }
}
