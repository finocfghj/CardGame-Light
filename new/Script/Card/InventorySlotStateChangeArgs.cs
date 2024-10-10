using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotStateChangeArgs
{
    public CardDifinition card;
    public bool active;

    public InventorySlotStateChangeArgs(CardDifinition card,bool active)
    {
        this.card = card;
        this.active = active;
    }
}
