using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    //���������
    private int hp;
    public int power; //���˹���
    public float lightedTime; //���Ʋ���Ҫ
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

    public System.Action hpChange; //��UI����,�����ܻ������ȵ�
    public System.Action lightChange;

    public void GetDamaged(AttackCard card) //���뿨����Ϊ�˼��㿨�Ƶĸ���Ч����ûд��
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

        // �ȴ�һ��ʱ���ִ�ж�Ӧ����Ϊ
        yield return new WaitForSeconds(0.5f);
        // ���繥�����
        // ...
        // ��ҿ�Ѫ
        FightManager.Instance.GetPlayerHit(power);
        // ...

        // �ȴ�����������
        yield return new WaitForSeconds(1);

        // ���Ŵ�������ص�֮ǰ״̬��
    }
}
