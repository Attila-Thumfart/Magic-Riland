using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Image Icon;

    Item Item;

    [SerializeField]
    private Shop Shop;

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
        if (Icon)
        {
            if (Item)
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
    }

    public void ClearSlot()
    {
        Item = null;

        Icon.sprite = null;
        Icon.enabled = false;
        StackSize.text = null;
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

    public void SellIndex()
    {
        Shop.SellItem(ButtonIndex);
    }

    public void PutItemInBox()
    {
        DeliveryBox.DeliverItem(ButtonIndex);
    }

    public void SetColorActive()
    {
        this.GetComponentInChildren<Image>().color = Color.green;
    }

    public void ResetColor()
    {
        this.GetComponentInChildren<Image>().color = Color.white;
    }
}
