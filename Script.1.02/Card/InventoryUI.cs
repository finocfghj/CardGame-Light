using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//创建时需要传入仓库和卡牌的ui预制体
//用于查看卡堆情况
public class InventoryUI : UIBase
{
    private Inventory inventory;
    [SerializeField] private GameObject inventorySlotUI;//后续可以改为导入
    [SerializeField] private List<CardUi> slots;

    public void Init(Inventory _inventory,GameObject slotUI)
    {
        if (inventorySlotUI == null && slotUI==null) return;

        inventorySlotUI=slotUI;

        if(slots==null) slots = new List<CardUi>();
        else slots.Clear();

        for (int i = 0; i < inventory.Slots.Count; i++)
        {
            var newSlot = Instantiate(inventorySlotUI, transform.position, Quaternion.identity);
            newSlot.transform.SetParent(this.transform, false);
            var slotScript = newSlot.AddComponent<CardUi>();
            slotScript.Init(inventory.Slots[i]);
            slots.Add(slotScript);
        }
    }

    public void ChangeView()
    {
        //改变卡牌遮挡顺序，但是我不会
    }
}
