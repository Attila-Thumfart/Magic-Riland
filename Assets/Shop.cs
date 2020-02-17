using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    [SerializeField]
    private int ShopSpace = 24;
    [SerializeField]
    private InventoryUI inventoryUI;


    public Item[] items;

    int TargetButtonIndex;

    private void Start()
    {
        items = new Item[ShopSpace];
    }

    public Item SelectItem(int TargetIndex)
    {
        TargetButtonIndex = TargetIndex;

        return items[TargetButtonIndex];
    }

    public void BuyItem()
    {

    }
}
