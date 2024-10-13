using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ʱ��Ҫ����ֿ�Ϳ��Ƶ�uiԤ����
//���ڲ鿴�������
public class InventoryUI : UIBase
{
    private Inventory inventory;
    [SerializeField] private GameObject inventorySlotUI;//�������Ը�Ϊ����
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
        //�ı俨���ڵ�˳�򣬵����Ҳ���
    }
}
