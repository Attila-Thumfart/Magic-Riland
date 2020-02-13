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

        Icon.sprite = Item.GetInventoryIcon();
        Icon.enabled = true;
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
       // Debug.Log("ButtenIndex given");
    }

    public int GetButtonIndex()
    {
        return ButtonIndex;
    }
}
