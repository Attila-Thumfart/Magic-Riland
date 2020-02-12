using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Image Icon;

    Item Item;

    public void AddItem (Item newItem)
    {
        Item = newItem;

        Icon.sprite = Item.GetInventoryIcon();
        Icon.enabled = true;
    }

    public void ClearSlot()
    {
        Item = null;

        Icon.sprite = null;
        Icon.enabled = false;
    }
}
