using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform ItemsParent;

    Inventory Inventory;

    InventorySlot[] Slots;

    // Start is called before the first frame update
    void Start()
    {
        Inventory = Inventory.instance;
        Inventory.onItemChangedCallback += UpdateUI;

        Slots = ItemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if(i < Inventory.items.Count)
            {
                Slots[i].AddItem(Inventory.items[i]);
            }
            else
            {
                Slots[i].ClearSlot();
            }
        }
    }

    void UpdateUI()
    {
        
    }
}
