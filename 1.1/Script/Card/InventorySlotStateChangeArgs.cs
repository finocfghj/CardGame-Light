using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotStateChangeArgs
{
    public InventorySlot slot;
    public bool active;

    public InventorySlotStateChangeArgs(InventorySlot slot,bool active)
    {
        this.slot = slot;
        this.active = active;
    }
}
