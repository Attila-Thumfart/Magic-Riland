using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    public Transform ItemsParent;

    Inventory Inventory;

    InventorySlot[] Slots;

    public GameObject inventoryUI;
    public GameObject Player;

    PlayerControls controls;

    public static InventoryUI InvUIInstance;

    private void Awake()
    {
        controls = new PlayerControls();

        if (InvUIInstance != null)
        {
            ;
            return;
        }
        InvUIInstance = this;

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        Inventory = Inventory.instance;
        Inventory.onItemChangedCallback += UpdateUI;

        Slots = ItemsParent.GetComponentsInChildren<InventorySlot>();

        controls.Gameplay.Inventar.started += ctx => ToggleUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*public void AddItemToSlot(int slot, Item _myItem)
    {
        Slots[slot].AddItem(_myItem);
    }

    public void RemoveItemFromSlot(int _slotNumber)
    {
        Slots[_slotNumber].ClearSlot();
    }
    */

    void UpdateUI()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (i < Inventory.items.Length)
            {
                Slots[i].AddItem(Inventory.items[i]);
            }
            else
            {
                Slots[i].ClearSlot();
            }
        }
    }

    private void ToggleUI()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        Player = GameObject.FindGameObjectWithTag("Player");

        if (inventoryUI.activeSelf)
        {
            Player.GetComponent<PlayerMovement>().enabled = false;
            Player.GetComponent<PlayerActions>().enabled = false;
        }
        else
        {
            Player.GetComponent<PlayerMovement>().enabled = true;
            Player.GetComponent<PlayerActions>().enabled = true;
        }
    }

    private void OnEnable() // This function enables the controls when the object becomes enabled and active
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable() // This function disables the controls when the object becomes disabled or inactive
    {
        controls.Gameplay.Disable();
    }
}
