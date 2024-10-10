using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardDifinition
{
    public Sprite _sprite;
    public float cost;//�ӷѿ��ķ����Ǹ���
    public string name;
    public bool canSeek;//�Ƿ�����Ե���Ϊ�����ͷ�
    public EnemyStat enemy;
    public string description;//��������


    public CardDifinition(Sprite sprite, float cost, string name, bool canSeek, string description)
    {
        _sprite = sprite;
        this.cost = cost;
        this.name = name;
        this.canSeek = canSeek;
        enemy = null;
        this.description = description;
    }
}
