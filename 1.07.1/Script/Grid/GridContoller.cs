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

public class GridContoller : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GridType type;

    public int index;

    private bool isActive;

    public float LightTime;

    public GameObject BlackSide;
    public GameObject LightSide; // 照亮后显示不同的一面

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
    }

    public void LightGrid(float time)
    {
        LightTime = time;
        Active = true;
    }

    private void ChangeSide()
    {
        BlackSide.SetActive(!isActive);
        LightSide.SetActive(isActive);

        ChangeToCardSide();
    }

    private void ChangeToCardSide()
    {
        if (isActive && type == GridType.Card)
        {
            CardDifinition card=CardInventory.Instance.GetCardRandomly();
            CardManager.Instance.AddCard(card);//随机添加一张卡
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(card);//调用fightui
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

    public bool DoActionForEnemy(AttackCard card) //被照亮才能执行,通过这个返回值判断操作是否可行,一般不会返回 false
    {
        if (!isActive) { return false; }
        if (type == GridType.Enemy)
        {
            EnemyStat enemy = GetComponent<EnemyStat>();
            if(enemy.isDie)return false;
            if (enemy.equipment != null)
            {
                //角色受伤
                StartCoroutine(enemy.DoAction());
            }
            enemy.GetDamaged((AttackCard)card);
        }
        else if (type == GridType.Card) return false;
        return true;
    }
    public bool DoActionForEnemy(RobCard card)
    {
        if (!isActive) { return false; }
        if (type == GridType.Enemy && card.type == CardType.Rob)
        {
            EnemyStat enemy = GetComponent<EnemyStat>();
            if (enemy.equipment == null)
            {
                CardDifinition newCard = CardInventory.Instance.GetCardRandomlyFromType(CardType.Attack);
                CardManager.Instance.AddCard(newCard);//随机添加一张卡
                UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(newCard);//调用fightui
            }
            PlayerManager.Instance.equipList.Add(enemy.equipment);
            enemy.equipment = null;
        }
        else if (type == GridType.Card) return false;
        return true;
    }
}
