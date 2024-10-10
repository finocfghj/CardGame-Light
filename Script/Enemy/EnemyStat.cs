using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    //���������
    private int hp;
    public int power;//���˹���
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

    public System.Action hpChange;//��UI����,�����ܻ������ȵ�
    public System.Action lightChange;

    public void GetDamaged(int damage,AttackCard card)//���뿨����Ϊ�˼��㿨�Ƶĸ���Ч����ûд��
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
            //���˱�ѡ�е���Ч��Ѫ����Ԥ������
            attackCard.enemy = this;
        }
        else if(other.gameObject.TryGetComponent<LightCard>(out var otherCard))
        {
            //���˱�ѡ�е���Ч
            otherCard.enemy = this;
        }
    }


}
