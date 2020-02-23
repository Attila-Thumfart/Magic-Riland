using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryBox : MonoBehaviour
{
   // public delegate void OnItemChanged();
   // public OnItemChanged onItemChangedCallback;

   // [SerializeField]
   // private int BoxSpace = 24;

    public GameObject Player;

    //private Item HoveredItem;

   // public Item[] boxItems;

    private void Start()
    {

    }

    public void DeliverItem(int TargetIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GameManager.GMInstance.AddDailyIncome(Inventory.instance.items[TargetIndex].GetSellingPrice());
        Inventory.instance.RemoveItemFromInventory(TargetIndex);
    }

   /* public void TakeItem(int TargetIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Inventory.instance.AddItemToInventory(boxItems[TargetIndex]);
        RemoveItemFromBox(TargetIndex);
    }

    public void SetHoveredItem(int hoveredItemID)
    {
        HoveredItem = boxItems[hoveredItemID];
    }

    public Item GetHoveredItem()
    {
        return HoveredItem;
    }

    public bool AddItemToBox(Item item)
    {
        for (int i = 0; i < boxItems.Length; i++)
        {
            if (boxItems[i] != null && boxItems[i].GetName() == item.GetName())
            {

                boxItems[i].ChangeNumberOfItemsBy(1);
                Debug.Log("You now have this item " + boxItems[i].GetNumberOfItems() + " times");
                Debug.Log(boxItems[i].GetNumberOfItems());

                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }

                return true;
            }
        }

        for (int i = 0; i < boxItems.Length; i++)
        {
            if (boxItems[i] == null)
            {
                boxItems[i] = item;
                boxItems[i].SetNumberOfItems(1);

                //inventoryUI.AddItemToSlot(i, item);

                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }

                return true;
            }

            if (i == boxItems.Length - 1 && boxItems[i] != null)
            {
                Debug.Log("Inventory full.");
                return false;
            }
        }
        return false;
    }
    
    public void RemoveItemFromBox(int _inventorySlot)
    {
        if (boxItems[_inventorySlot].GetNumberOfItems() == 1)
        {
            boxItems[_inventorySlot] = null;
            Debug.Log("This was the last of its kind...");
        }

        else
        {
            boxItems[_inventorySlot].ChangeNumberOfItemsBy(-1);
            Debug.Log("The item " + boxItems[_inventorySlot].GetName() + "is now a bit lonlier " + boxItems[_inventorySlot].GetNumberOfItems());
        }
        //inventoryUI.RemoveItemFromSlot(_inventorySlot);

        // inventorySlot.ClearSlot();

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void ClearBox()
    {
        for (int i = 0; i < boxItems.Length; i++)
        {
            if (boxItems[i] != null)
            {
                // DailyMoney = DailyMoney + boxItems[i].GetSellingPrice();
                boxItems[i] = null;
            }
        }

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }*/
}
