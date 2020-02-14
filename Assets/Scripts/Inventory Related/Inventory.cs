using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            ;
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    [SerializeField]
    private int InventorySpace = 30;
    [SerializeField]
    private InventoryUI inventoryUI;

    public Item[] items;

    int TargetButtonIndex;
    int PreviousIndex;

    Item SelectedItem;
    Item SwappedItem;

    private void Start()
    {
        items = new Item[InventorySpace];
    }

    public bool AddItemToInventory(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;

                inventoryUI.AddItemToSlot(i, item);

                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }

                return true;
            }

            if (i == items.Length - 1 && items[i] != null)
            {
                Debug.Log("Inventory full.");
                return false;
            }
        }
        return false;
    }

    public void RemoveItemFromInventory(int _inventorySlot)
    {
        items[_inventorySlot] = null;
        inventoryUI.RemoveItemFromSlot(_inventorySlot);

        //inventorySlot.ClearSlot();

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void PickUpItemInInventory(int TargetIndex)
    {
        TargetButtonIndex = TargetIndex;
        // Debug.Log("Changed TragetButtonIndex");
        // Debug.Log(TargetButtonIndex);

        if (SelectedItem != null)
        {
            SwappedItem = items[TargetButtonIndex];
            items[TargetButtonIndex] = SelectedItem;
            items[PreviousIndex] = SwappedItem;
            SelectedItem = null;
            // Debug.Log("Item swapped");
        }
        else if (SelectedItem == null)
        {
            SelectedItem = items[TargetButtonIndex];
            PreviousIndex = TargetButtonIndex;
            Debug.Log("Item selected");
        }
    }

    public Item GetFirstItem()
    {
        /*
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].GetIsSeed())
            {
                return items[i];
            }
        }
        return null;*/

        return items[0];
    }
}
