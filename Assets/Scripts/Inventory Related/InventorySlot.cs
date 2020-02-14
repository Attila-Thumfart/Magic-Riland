using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Image Icon;

    Item Item;

    private int ButtonIndex;

    private void Start()
    {
        ButtonIndex = transform.GetSiblingIndex();
    }

    public void AddItem (Item newItem)
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

    public void GiveIndexToInventory()
    {
        Inventory.instance.PickUpItemInInventory(ButtonIndex);
    }

    public int GetButtonIndex()
    {
        return ButtonIndex;
    }
}
