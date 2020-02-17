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
        Inventory.instance.AddItemToInventory(shopItems[TargetIndex]);
        // player.money -= shopItems[TargetIndex].GetCost();
    }
}
