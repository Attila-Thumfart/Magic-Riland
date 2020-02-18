using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ShopUI : Interactable
{
    public Transform ItemsParent;
    public Transform ShopParent;

    Inventory Inventory;

    InventorySlot[] InventorySlots;
    ShopSlot[] ShopSlots;

    public GameObject shopUI;

    public static InventoryUI InvUIInstance;

    private Item DisplayItem;

    [SerializeField]
    private Image DisplayIcon;

    [SerializeField]
    private TMP_Text DescriptionDisplay;

    PlayerControls controls;

    [SerializeField]
    Shop Shop;

    public override void Awake()
    {
        base.Awake();
        controls = new PlayerControls();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        Inventory = Inventory.instance;

        Inventory.onItemChangedCallback += UpdateUI;

        InventorySlots = ItemsParent.GetComponentsInChildren<InventorySlot>();
        ShopSlots = ShopParent.GetComponentsInChildren<ShopSlot>();

        UpdateShopUI();

        controls. Gameplay.Erde.started += ctx => DeactivateUI();  // Erde is used because I cant for the love of god figure out how the Unity Input Action System works
    }

    public override void Interact()
    {
        base.Interact();
        ActivateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            if (i < Inventory.items.Length)
            {
                InventorySlots[i].AddItem(Inventory.items[i]);
            }
            else
            {
                InventorySlots[i].ClearSlot();
            }
        }
    }

    public void UpdateShopUI()
    {
        for (int i = 0; i < ShopSlots.Length; i++)
        {
            if (i < Shop.shopItems.Length)
            {
                ShopSlots[i].AddItem(Shop.shopItems[i]);
            }
            else
            {
                ShopSlots[i].ClearSlot();
            }
        }
    }

    private void ActivateUI()
    {
        shopUI.SetActive(true);

       // if (shopUI.activeSelf)
        {
            Player.GetComponent<PlayerMovement>().enabled = false;
            Player.GetComponent<PlayerActions>().enabled = false;
        }
    }

    private void DeactivateUI()
    {
        Debug.Log("Cancel");
        if (shopUI.activeSelf)
        {
            shopUI.SetActive(false);

           // if (!shopUI.activeSelf)
            //{
                Player.GetComponent<PlayerMovement>().enabled = true;
                Player.GetComponent<PlayerActions>().enabled = true;
            //}
        }
    }

    public void ItemDescriptionDisplay()
    {
        DisplayItem = Inventory.instance.GetHoveredItem();

        if (DisplayItem != null)
        {
            DisplayIcon.sprite = DisplayItem.GetInventoryIcon();
            DisplayIcon.enabled = true;
            DescriptionDisplay.text = DisplayItem.GetDescription();
        }
    }

    public void ClearDescriptionDisplay()
    {
        DisplayIcon.sprite = null; ;
        DisplayIcon.enabled = false;
        DescriptionDisplay.text = null;
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
