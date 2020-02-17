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
    [SerializeField]
    private InventoryUI inventoryUI;

    public Item[] items;
    private int NumberOfAllowedItems = 10;


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
            if (items[i] != null && items[i].GetName() == item.GetName())
            {
                if (items[i].GetNumberOfItems() < NumberOfAllowedItems)
                {
                    items[i].ChangeNumberOfItemsBy(1);
                    Debug.Log("You now have this item " + items[i].GetNumberOfItems() + " times");
                    Debug.Log(items[i].GetNumberOfItems() + "/" + NumberOfAllowedItems);

                    if (onItemChangedCallback != null)
                    {
                        onItemChangedCallback.Invoke();
                    }

                    return true;
                }
                else
                {
                    Debug.Log("You already have enough of those, dont be greedy!");
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
                Debug.Log("Inventory full.");
                return false;
            }
        }
        return false;
    }

    public void RemoveItemFromInventory(int _inventorySlot)
    {
        if (items[_inventorySlot].GetNumberOfItems() == 1)
        {
            items[_inventorySlot] = null;
            Debug.Log("This was the last of its kind...");
        }

        else
        {
            items[_inventorySlot].ChangeNumberOfItemsBy(-1);
            Debug.Log("The item " + items[_inventorySlot].GetName() + "is now a bit lonlier " + items[_inventorySlot].GetNumberOfItems());
        }
        //inventoryUI.RemoveItemFromSlot(_inventorySlot);

        // inventorySlot.ClearSlot();

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
        }
        else if (SelectedItem == null)
        {
            SelectedItem = items[TargetButtonIndex];
            PreviousIndex = TargetButtonIndex;
            inventoryUI.ItemDescriptionDisplay();
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

    public Item GetCurrentItem()
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
        return items[TargetButtonIndex];
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
