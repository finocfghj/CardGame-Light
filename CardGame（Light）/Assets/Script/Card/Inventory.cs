using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> slots;

    public List<InventorySlot> Cards => slots;

    public InventorySlot FindCard(CardDifinition orderedCard)
    {
        return slots.FirstOrDefault(slot => slot.Card == orderedCard);
    }

    public void AddCard(CardDifinition card)
    {
        InventorySlot newSlot = new InventorySlot(card);
        slots.Add(newSlot);
    }

    public void RemoveCard(CardDifinition card)
    {
        InventorySlot cardToRemove=FindCard(card);

        slots.Remove(cardToRemove);
    }

    public List<T> Outoforder<T>(List<T> bag)//´òÂÒ
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
}
