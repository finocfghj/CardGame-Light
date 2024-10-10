using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> slots;

    public int activeIndex;//玩家在卡堆预览中选中牌查看操作

    public List<InventorySlot> Cards => slots;

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
        newSlot.active = false;
        newSlot.index = slots.Count;

        slots.Add(newSlot);
    }

    public void RemoveCard(CardDifinition card)
    {
        InventorySlot cardToRemove=FindCard(card);

        slots.Remove(cardToRemove);
    }

    public void RemoveCard(int delIndex)
    {
        slots.RemoveAt(delIndex);
    }

    public List<T> Outoforder<T>(List<T> bag)//打乱
    {
        Random randomNum = new Random();
        int index = 0;
        T temp;
        for (int i = 0; i < bag.Count; i++)
        {
            index = randomNum.Next(0, bag.Count - 1);
            if (index != i)
            {
                temp = bag[i];
                bag[i] = bag[index];
                bag[index] = temp;
            }
        }
        return bag;
    }

    public CardDifinition Getcard()
    {
        CardDifinition outCard = slots[0].Card;
        RemoveCard(outCard);
        return outCard;
    }
}
