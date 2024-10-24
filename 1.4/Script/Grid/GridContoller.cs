using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public enum GridType
{
    Enemy,
    Card
}

public class GridContoller : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler
{
    public GridType type;

    public int index;

    private bool isActive;

    public float LightTime;

    public GameObject BlackSide;
    public GameObject LightSide; // ��������ʾ��ͬ��һ��

    private bool Actived;

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
        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        collider.offset = Vector3.zero;
        collider.size = new Vector3(2,2,2);

        type = _type;
        index = _index;
        isActive = false;

        BlackSide= Instantiate(_blackSide,Vector3.zero,Quaternion.identity);
        BlackSide.transform.SetParent(transform,false);
        LightSide= Instantiate(_lightSide,Vector3.zero, Quaternion.identity);
        LightSide.transform.SetParent(transform,false);

        SetUpEnemyGrid();

        Active = false;
    }

    private void Update()
    {
        if (isActive)
        {
            LightTime = TimeCounter.Instance.TimeDecrease(LightTime);
            if (LightTime < 0) 
            {
                Active = false;
            }
        }
    }

    private void SetUpEnemyGrid()
    {
        if (type != GridType.Enemy) return;

        var newEnemy=gameObject.AddComponent<EnemyStat>();
        newEnemy.Init(EnemyInventory.Instance.GetEnemyRandomly());
        EnemyManager.Instance.AddEnemy(newEnemy);
    }

    public void LightGrid(float time)
    {
        LightTime = time;
        Active = true;
    }

    private void ChangeSide()
    {
        Actived = true;
        BlackSide.SetActive(!isActive);
        LightSide.SetActive(isActive);

        ChangeToCardSide();
    }

    private void ChangeToCardSide()
    {
        if (isActive && type == GridType.Card)
        {
            CardDifinition card=CardInventory.Instance.GetCardRandomly();
            CardManager.Instance.AddCard(card);//������һ�ſ�
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(card);//����fightui
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        NineGridController.Instance.gridChoosed(index);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        NineGridController.Instance.gridChoosed(-1);
    }

    public bool DoActionForEnemy(AttackCard card) //����������ִ��,ͨ���������ֵ�жϲ����Ƿ����,һ�㲻�᷵�� false
    {
        if (type == GridType.Enemy)
        {
            EnemyStat enemy = GetComponent<EnemyStat>();
            if(enemy.isDie)return false;
            if(enemy.enemy.ArmName=="����")
            {
                FightManager.Instance.GetPlayerHit(1);
            }
            if(!Active)
            {
                enemy.GetDamaged(card , true);
            }
            else
            {
                enemy.GetDamaged(card);
            }
            if (enemy.HP!=0)
            {
                //��ɫ����
                StartCoroutine(enemy.DoAction());
            }
        }
        else if (type == GridType.Card) return false;
        return true;
    }
    public bool DoActionForEnemy(RobCard card)
    {
        if (!Actived) { return false; }
        if (type == GridType.Enemy && card.type == CardType.Rob)
        {
            EnemyStat enemy = GetComponent<EnemyStat>();
            if (enemy.equipment == null)
            {
                CardDifinition newCard = CardInventory.Instance.GetCardRandomlyFromType(CardType.Attack);
                CardManager.Instance.AddCard(newCard);//������һ�ſ�
                UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(newCard);//����fightui
            }
            else 
            {
                UIManager.Instance.GetUI<EquipmentUI>("EquipmentUI").CreateEquipmentItem(enemy.equipment.sprite,enemy.equipment.EquipmentName,enemy.equipment.description,enemy.equipment.descriptionPos);
                enemy.equipment = null;
            }
        }
        else if (type == GridType.Card) return false;
        return true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Active && type == GridType.Enemy && !FightManager.Instance.isUsingCard) 
        {
            FeatureUI ui=(FeatureUI)UIManager.Instance.ShowUI<FeatureUI>("FeatureUI");
            ui.Init(GetComponent<EnemyStat>());
        }
    }
}
