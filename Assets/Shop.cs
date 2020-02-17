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

    private Item SelectedItem;

    public Item[] items;

    int TargetButtonIndex;

    private void Start()
    {
        items = new Item[ShopSpace];
    }

    public Item GetCurrentItem(int TargetIndex)
    {
        TargetButtonIndex = TargetIndex;

        SelectedItem = items[TargetButtonIndex];

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
