using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class DeliveryBoxUI : Interactable
{
    public Transform ItemsParent;
    public Transform BoxParent;

    Inventory Inventory;

    InventorySlot[] InventorySlots;
    //DeliveryBoxSlot[] DeliveryBoxSlots;

    public GameObject deliveryBoxUI;

    public static InventoryUI InvUIInstance;

    private Item DisplayItem;

    private GameObject Menus;
    private GameObject InventoryUI;
    private GameObject actualDeliveryBox;

    [SerializeField]
    private Image DisplayIcon;

    [SerializeField]
    private TMP_Text DescriptionDisplay, DailyIncomeDisplay;

    PlayerControls controls;

    [SerializeField]
    DeliveryBox DeliveryBox;

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
        //Inventory.onItemChangedCallback += UpdateDeliveryBoxUI;

        InventorySlots = ItemsParent.GetComponentsInChildren<InventorySlot>();
        //DeliveryBoxSlots = BoxParent.GetComponentsInChildren<DeliveryBoxSlot>();

        //UpdateDeliveryBoxUI();

        controls.Gameplay.Erde.started += ctx => DeactivateUI();  // Erde is used because I cant for the love of god figure out how the Unity Input Action System works


        DailyIncomeDisplay.text = GameManager.GMInstance.GetDailyIncome().ToString();

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

        DailyIncomeDisplay.text = GameManager.GMInstance.GetDailyIncome().ToString();
    }

    /*public void UpdateDeliveryBoxUI()
    {
        for (int i = 0; i < DeliveryBoxSlots.Length; i++)
        {
            if (i < DeliveryBox.boxItems.Length)
            {
                DeliveryBoxSlots[i].AddItem(DeliveryBox.boxItems[i]);
            }
            else
            {
                DeliveryBoxSlots[i].ClearSlot();
            }
        }
    }*/

    private void ActivateUI()
    {
        Menus = GameObject.Find("MenuManager");
        Menus.GetComponentInChildren<PauseMenu>().enabled = false;
        InventoryUI = GameObject.Find("Inventory");
        InventoryUI.GetComponent<InventoryUI>().enabled = false;

        deliveryBoxUI.SetActive(true);

        // if (shopUI.activeSelf)
        {
            Player.GetComponent<PlayerMovement>().enabled = false;
            Player.GetComponent<PlayerActions>().enabled = false;
        }
    }

    private void DeactivateUI()
    {
        if (deliveryBoxUI.activeSelf)
        {
            deliveryBoxUI.SetActive(false);

            //DeliveryBox.ClearBox();

            Menus.GetComponentInChildren<PauseMenu>().enabled = true;
            InventoryUI.GetComponent<InventoryUI>().enabled = true;

            // if (!shopUI.activeSelf)
            //{
            Player.GetComponent<PlayerMovement>().enabled = true;
            Player.GetComponent<PlayerActions>().enabled = true;
            //}
        }
    }
    public void InventoryItemDescriptionDisplay()
    {
        DisplayItem = Inventory.instance.GetHoveredItem();

        if (DisplayItem != null)
        {
            DisplayIcon.sprite = DisplayItem.GetInventoryIcon();
            DisplayIcon.enabled = true;
            DescriptionDisplay.text = DisplayItem.GetDescription();
        }
        else if (DisplayItem == null)
        {
            DisplayIcon.sprite = null;
            DisplayIcon.enabled = false;
            DescriptionDisplay.text = null;
        }
    }

   /* public void BoxItemDescriptionDisplay()
    {
        DisplayItem = DeliveryBox.GetHoveredItem();

        if (DisplayItem != null)
        {
            DisplayIcon.sprite = DisplayItem.GetInventoryIcon();
            DisplayIcon.enabled = true;
            DescriptionDisplay.text = DisplayItem.GetDescription();
        }
        else if (DisplayItem == null)
        {
            DisplayIcon.sprite = null;
            DisplayIcon.enabled = false;
            DescriptionDisplay.text = null;
        }
    }

    public void ClearDescriptionDisplay()
    {
        DisplayIcon.sprite = null; ;
        DisplayIcon.enabled = false;
        DescriptionDisplay.text = null;
    }*/

    private void OnEnable() // This function enables the controls when the object becomes enabled and active
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable() // This function disables the controls when the object becomes disabled or inactive
    {
        controls.Gameplay.Disable();
    }
}
