using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSlot : MonoBehaviour
{
    [SerializeField]
    private Image Icon;

    Item Item;

    [SerializeField]
    private Shop Shop;

    private int ButtonIndex;

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
        }
        else
        {
            Icon.sprite = null; ;
            Icon.enabled = false;
        }
    }

    public void ClearSlot()
    {
        Item = null;

        Icon.sprite = null;
        Icon.enabled = false;
    }

    public void BuyIndex()
    {
        Shop.BuyItem(ButtonIndex);
    }

    public void GiveIndexToInventory()
    {
        Inventory.instance.PickUpItemInInventory(ButtonIndex);
    }

    public void GiveButtonIndexToUI()
    {
        Inventory.instance.SetHoveredItem(ButtonIndex);
    }

    public int GetButtonIndex()
    {
        return ButtonIndex;
    }
}
