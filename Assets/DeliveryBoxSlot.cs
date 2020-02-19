﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeliveryBoxSlot : MonoBehaviour
{
    [SerializeField]
    private Image Icon;

    Item Item;

    [SerializeField]
    private DeliveryBox DeliveryBox;

    private int ButtonIndex;

    [SerializeField]
    private TMP_Text StackSize;

    private void Start()
    {
        ButtonIndex = transform.GetSiblingIndex();
    }

    public void AddItem(Item newItem)
    {
        Item = newItem;
        if (Item != null)
        {
            Icon.sprite = Item.GetInventoryIcon();
            Icon.enabled = true;

            if (Item.GetNumberOfItems() > 1)
            {
                StackSize.text = Item.GetNumberOfItems().ToString();
            }
            else
            {
                StackSize.text = null;
            }
        }
        else
        {
            Icon.sprite = null; ;
            Icon.enabled = false;
            StackSize.text = null;
        }
    }

    public void ClearSlot()
    {
        Item = null;

        Icon.sprite = null;
        Icon.enabled = false;
        StackSize.text = null;
    }

    /*public void TakeIndex()
    {
        DeliveryBox.TakeItem(ButtonIndex);
    }*/

    public void GiveIndexToInventory()
    {
        Inventory.instance.PickUpItemInInventory(ButtonIndex);
    }

    /*public void GiveButtonIndexToBoxUI()
    {
        DeliveryBox.SetHoveredItem(ButtonIndex);
    }*/

    public int GetButtonIndex()
    {
        return ButtonIndex;
    }
}
