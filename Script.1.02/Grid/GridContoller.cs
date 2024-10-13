using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum GridType
{
    Enemy,
    Card
}

public class GridContoller :IPointerEnterHandler,IPointerExitHandler
{
    public GridType type;

    public int index;

    private bool isActive;

    public Transform transform;  

    public GameObject BlackSide;
    public GameObject LightSide;//照亮后显示不同的一面

    public bool Active
    {
        get { return isActive; }
        set
        {
            isActive = value;
            ChangeSide();
        }
    }

    public void Init(GridType _type,int _index,GameObject _blackSide,GameObject _lightSide,Transform transform)
    {
        type = _type;
        index = _index;
        isActive = false;
        BlackSide = _blackSide;
        LightSide = _lightSide;
        this.transform = transform;
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

    public void DoAction()
    {
        //执行对应操作
    }
}
