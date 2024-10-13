using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Attack,
    Light,
    Rob
}

[CreateAssetMenu(fileName ="Inventory/CardDifinition",menuName ="New Card Definition")]
public class CardBase:ScriptableObject
{
    public Sprite _sprite;
    public float cost;//�ӷѿ��ķ����Ǹ���
    public string _name;
    public bool canSeek;//�Ƿ�����Ե���Ϊ�����ͷ�
    public string description;//��������
    public CardType type;
}
