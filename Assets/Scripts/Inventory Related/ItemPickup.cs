using UnityEngine;

public class ItemPickup : Interactable          //inherits from the class interactable
{
    public Item item;                           

    public override void Interact()
    {
        base.Interact();
        PickUp();                           //picks up an item
    }

    void PickUp()           
    {
        bool wasPickedUp = Inventory.instance.AddItemToInventory(item);     //checks if the item was picked up and adds it to the Players inventory

        if (wasPickedUp)
        {   
            //Destroy(gameObject);                                          //destroys that item in the scene
        }
    }
}
