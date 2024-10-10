using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.CullingGroup;


[Serializable]
public class InventorySlot
{
    public event EventHandler<InventorySlotStateChangeArgs> StateChanged;

    private CardDifinition card;

    public int index;

    public bool active
    {
        get 
        { return active; }
        set
        {
            active = value;
            NotifyAboutStateChange();
        }
    }

    public InventorySlot(CardDifinition card)
    {
        this.card = card;
    }

    public CardDifinition Card
    {
        get { return card; }
        set 
        {
            card = value; 
            NotifyAboutStateChange();
        }
    }

    private void NotifyAboutStateChange()
    {
        StateChanged?.Invoke(this, new InventorySlotStateChangeArgs(this,active));
    }

}
