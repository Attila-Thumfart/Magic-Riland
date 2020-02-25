﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour
{
    public Transform ItemsParent;

    Inventory Inventory;

    InventorySlot[] Slots;

    public GameObject inventoryUI;
    public GameObject Player;

    [SerializeField]
    private GameObject InGameUI;

    private GameObject Menus;

    PlayerControls controls;

    public static InventoryUI InvUIInstance;

    private Item DisplayItem;

    [SerializeField]
    private Image DisplayIcon, InGameDisplay;

    [SerializeField]
    private TMP_Text DescriptionDisplay, PlayerMoneyDisplay, InGameStackDisplay;

    private void Awake()
    {
        controls = new PlayerControls();

        if (InvUIInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        InvUIInstance = this;

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        InGameUI.SetActive(false);

        Inventory = Inventory.instance;

        Inventory.onItemChangedCallback += UpdateUI;

        Slots = ItemsParent.GetComponentsInChildren<InventorySlot>();

        controls.Gameplay.Inventar.started += ctx => ToggleUI();
        controls.Gameplay.Erde.started += ctx => DeactivateUI();

        PlayerMoneyDisplay.text = GameManager.GMInstance.GetPlayerMoney().ToString();
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

    public void OnLevelWasLoaded(int level)
    {
        if(level == 0)
            InGameUI.SetActive(false);
    }

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

        ItemDescriptionDisplay();

        if (Inventory.instance.GetCurrentItem() == null)
            ClearDescriptionDisplay();

        PlayerMoneyDisplay.text = GameManager.GMInstance.GetPlayerMoney().ToString();

        if (Inventory.instance.GetSelectedItem() == null)
        {
            SetButtonColorSelected();
        }

        if (InGameDisplay)
        {
            if (Inventory.instance.GetCurrentItem())
            {
                InGameDisplay.sprite = Inventory.instance.GetCurrentItem().GetInventoryIcon();
                InGameStackDisplay.text = Inventory.instance.GetCurrentItem().GetNumberOfItems().ToString();
                InGameDisplay.enabled = true;

                // InGameStackDisplay.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 15);
                //InGameStackDisplay.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 24);
                // InGameStackDisplay.fontSize = 14;
            }
            else
            {
                InGameDisplay.sprite = null;
                InGameStackDisplay.text = null;
                InGameDisplay.enabled = false;
            }
        }
    }

    private void ToggleUI()
    {
        UpdateUI();

        PlayerMoneyDisplay.text = GameManager.GMInstance.GetPlayerMoney().ToString();

        Menus = GameObject.Find("MenuManager");

        if (!Menus.GetComponentInChildren<PauseMenu>().GetIsPaused())
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            Player = GameObject.FindGameObjectWithTag("Player");
            Inventory.instance.ResetSelectedItem();

            if (inventoryUI.activeSelf)
            {
                Player.GetComponent<PlayerMovement>().enabled = false;
                Player.GetComponent<PlayerActions>().enabled = false;
                Menus.GetComponentInChildren<PauseMenu>().enabled = false;
            }
            else
            {
                Player.GetComponent<PlayerMovement>().enabled = true;
                Player.GetComponent<PlayerActions>().enabled = true;
                Menus.GetComponentInChildren<PauseMenu>().enabled = true;
            }
        }
    }

    private void DeactivateUI()
    {
        if (inventoryUI.activeSelf)
        {
            inventoryUI.SetActive(false);

            // Menus.GetComponentInChildren<PauseMenu>().enabled = true;

            // if (!shopUI.activeSelf)
            //{
            Player.GetComponent<PlayerMovement>().enabled = true;
            Player.GetComponent<PlayerActions>().enabled = true;
            Menus.GetComponentInChildren<PauseMenu>().enabled = true;
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
            DescriptionDisplay.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110.29f);
            DescriptionDisplay.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
            DescriptionDisplay.fontSize = 14;
        }
        else
        {
            DisplayIcon.sprite = null; ;
            DisplayIcon.enabled = false;
            DescriptionDisplay.text = null;
        }
    }

    public void ClearDescriptionDisplay()
    {
        DisplayIcon.sprite = null; ;
        DisplayIcon.enabled = false;
        DescriptionDisplay.text = null;
    }

    public void SetButtonColorSelected()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].ResetColor();
        }

        if (Inventory.instance.GetCurrentItem() != null)
        {
            Slots[Inventory.instance.GetCurrentItemIndex()].SetColorActive();
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
