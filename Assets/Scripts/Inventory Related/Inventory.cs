﻿using System.Collections;
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
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    [SerializeField]
    private int InventorySpace = 30;

    public Item[] items;
    private int NumberOfAllowedItems = 10;


    int TargetButtonIndex;
    int PreviousIndex;

    Item CurrentItem;
    Item HoveredItem;
    Item SelectedItem;
    Item SwappedItem;

    [SerializeField]
    Item StartItem;

    private void Start()
    {
        items = new Item[InventorySpace];

        for (int i = 0; i < 10; i++)
            AddItemToInventory(StartItem);
    }

    public bool AddItemToInventory(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null && items[i].GetName() == item.GetName())
            {
                if (items[i].GetNumberOfItems() < NumberOfAllowedItems)
                {
                    items[i].ChangeNumberOfItemsBy(1);
                    //Debug.Log("You now have this item " + items[i].GetNumberOfItems() + " times");
                    //Debug.Log(items[i].GetNumberOfItems() + "/" + NumberOfAllowedItems);

                    if (onItemChangedCallback != null)
                    {
                        onItemChangedCallback.Invoke();
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                items[i].SetNumberOfItems(1);

                //inventoryUI.AddItemToSlot(i, item);

                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }

                return true;
            }

            if (i == items.Length - 1 && items[i] != null)
            {
                return false;
            }
        }
        return false;
    }

    public void RemoveItemFromInventory(int _inventorySlot)
    {
        if (items[_inventorySlot] != null)
        {
            if (items[_inventorySlot].GetNumberOfItems() == 1)
            {
                items[_inventorySlot] = null;
                CurrentItem = null;
            }

            else
            {
                items[_inventorySlot].ChangeNumberOfItemsBy(-1);
            }
            //inventoryUI.RemoveItemFromSlot(_inventorySlot);

            // inventorySlot.ClearSlot();
        }

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void UseItemFromSlot()
    {
        items[TargetButtonIndex] = null;

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void PickUpItemInInventory(int TargetIndex)
    {
        TargetButtonIndex = TargetIndex;

        if (SelectedItem != null)
        {
            SwappedItem = items[TargetButtonIndex];
            items[TargetButtonIndex] = SelectedItem;
            items[PreviousIndex] = SwappedItem;
            SelectedItem = null;
            CurrentItem = null;
        }
        else if (SelectedItem == null)
        {
            SelectedItem = items[TargetButtonIndex];
            PreviousIndex = TargetButtonIndex;
            CurrentItem = SelectedItem;

            //inventoryUI.ItemDescriptionDisplay();
        }

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void TrashcanItem()
    {
        if (SelectedItem != null)
        {
            items[TargetButtonIndex] = null;
            SelectedItem = null;
        }

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void SetHoveredItem(int hoveredItemID)
    {
        HoveredItem = items[hoveredItemID];
    }

    public Item GetHoveredItem()
    {
        return HoveredItem;
    }

    public int GetCurrentItemIndex()
    {
        return TargetButtonIndex;
    }

    public int GetPreviousIndex()
    {
        return PreviousIndex;
    }

    public Item GetCurrentItem()
    {
        return CurrentItem;
        //return items[TargetButtonIndex]; //May need this still
    }

    public Item GetSelectedItem()
    {
        return SelectedItem;
    }

    public void ResetSelectedItem()
    {
        SelectedItem = null;
    }
}
