using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    [SerializeField]
    private int ShopSpace = 24;

    public GameObject Player;

    private Item HoveredItem;

    public Item[] shopItems;

    private void Start()
    {
        // shopItems = new Item[ShopSpace];
    }

    public void SellItem(int TargetIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Inventory.instance.RemoveItemFromInventory(TargetIndex);
        // player.money += shopItems[TargetIndex].GetSellingPrice();
    }

    public void BuyItem(int TargetIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if (GameManager.GMInstance.RemovePlayerMoney(shopItems[TargetIndex].GetCost()))
        {
           // GameManager.GMInstance.RemovePlayerMoney(shopItems[TargetIndex].GetCost());
            Inventory.instance.AddItemToInventory(shopItems[TargetIndex]);
        }
    }

    public void SetHoveredItem(int hoveredItemID)
    {
        HoveredItem = shopItems[hoveredItemID];
    }

    public Item GetHoveredItem()
    {
        return HoveredItem;
    }
}
