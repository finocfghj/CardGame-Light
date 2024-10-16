using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum GridType
{
    Enemy,
    Card
}

public class GridContoller : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GridType type;

    public int index;

    private bool isActive;

    public GameObject BlackSide;
    public GameObject LightSide; // ��������ʾ��ͬ��һ��

    public bool Active
    {
        get { return isActive; }
        set
        {
            isActive = value;
            ChangeSide();
        }
    }

    public void Init(GridType _type,int _index,GameObject _blackSide,GameObject _lightSide)
    {
        type = _type;
        index = _index;
        isActive = false;
        BlackSide = _blackSide;
        LightSide = _lightSide;
    }

    private void ChangeSide()
    {
        BlackSide.SetActive(!isActive);
        LightSide.SetActive(isActive);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        NineGridController.Instance.gridChoosed(index);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        NineGridController.Instance.gridChoosed(-1);
    }

    public bool DoAction(CardDifinition card) //����������ִ��,ͨ���������ֵ�жϲ����Ƿ����
    {
        if (!isActive) { return false; }
        if (type == GridType.Enemy && card.type == CardType.Attack)
        {
            EnemyStat enemy = GetComponent<EnemyStat>();
            if (enemy.equipment != null)
            {
                //��ɫ����
                FightManager.Instance.GetPlayerHit(enemy.equipment.modifier);
            }
            enemy.GetDamaged((AttackCard)card);
        }
        else if (type == GridType.Enemy && card.type == CardType.Rob)
        {
            EnemyStat enemy = GetComponent<EnemyStat>();
            if (enemy.equipment == null) return false;
            //�����Լ���װ����
            enemy.equipment = null;
        }
        else if (type == GridType.Card) return false;
        return true;
    }
}
