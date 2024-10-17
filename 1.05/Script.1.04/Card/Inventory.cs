using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Inventory
{
    [SerializeField] private List<InventorySlot> slots;

    public int activeIndex;//玩家在卡堆预览中选中牌查看操作

    public List<InventorySlot> Slots => slots;


    public InventorySlot FindCard(CardDifinition orderedCard)
    {
        return slots.FirstOrDefault(slot => slot.Card == orderedCard);
    }

    public int CountCard(CardDifinition card)
    {
        int sum = 0;
        foreach(InventorySlot slot in slots)
        {
            if(slot.Card == card) sum++;
        }
        return sum;
    }

    public void AddCard(CardDifinition card)
    {
        if(slots==null)slots = new List<InventorySlot>();

        InventorySlot newSlot = new InventorySlot(card);
        newSlot.Active = false;
        newSlot.index = slots.Count;

        slots.Add(newSlot);
    }

    public void RemoveCard(CardDifinition card)
    {
        InventorySlot cardToRemove=FindCard(card);

        slots.Remove(cardToRemove);
    }

    public CardDifinition RemoveCard(int delIndex)
    {
        CardDifinition card=slots[delIndex].Card;
        slots.RemoveAt(delIndex);
        return card;
    }

    public void Outoforder()//打乱
    {
        Random randomNum = new Random();
        int index = 0;
        InventorySlot temp;
        for (int i = 0; i < slots.Count; i++)
        {
            index = randomNum.Next(0, slots.Count - 1);
            if (index != i)
            {
                temp = slots[i];
                slots[i] = slots[index];
                slots[index] = temp;
            }
        }
    }

    public CardDifinition Getcard()
    {
        CardDifinition outCard = slots[0].Card;
        RemoveCard(outCard);
        return outCard;
    }

    public CardDifinition GetCardWithOutDel()
    {
        Outoforder();
        CardDifinition outCard = slots[0].Card;
        return outCard;
    }

    public void DeleteAllCard()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i] = null;
        }
        slots.Clear();
    }
}
