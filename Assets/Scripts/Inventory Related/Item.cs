﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "InventoryItem")]
public class Item : ScriptableObject
{
    [SerializeField]
    private string Name = "New Item", Description = "This is an Item";

    [SerializeField]
    private bool IsSeed;

    [SerializeField]
    private int SellingPrice, Cost;

    [SerializeField]
    private Sprite InventoryIcon;

    [SerializeField]
    private int GrowthRateUntilSprout, GrowtRateUntilMedium, GrowthRateUntilFinished;

    [SerializeField]
    private GameObject GrowthModelSeed, GrowthModelSprout, GrowthModelMedium, GrowthModelFinished, GrowthModelWithered;

    [SerializeField]
    private GameObject HandModel;

    private int NumberOfItems = 1;


    [SerializeField]
    Item FinishedPlant;



    #region Getter

    public string GetName()
    {
        return Name;
    }

    public string GetDescription()
    {
        return Description;
    }

    public int GetSellingPrice()
    {
        return SellingPrice;
    }

    public int GetCost()
    {
        return Cost;
    }

    public bool GetIsSeed()
    {
        return IsSeed;
    }

    public Sprite GetInventoryIcon()
    {
        return InventoryIcon;
    }

    public int GetGrowthRateUntilSprout()
    {
        return GrowthRateUntilSprout;
    }

    public int GetGrowthRateUntilMedium()
    {
        return GrowtRateUntilMedium;
    }

    public int GetGrowthRateUntilFinished()
    {
        return GrowthRateUntilFinished;
    }

    public GameObject GetGrowthModelSeed()
    {
        return GrowthModelSeed;
    }

    public GameObject GetGrowthModelSprout()
    {
        return GrowthModelSprout;
    }

    public GameObject GetGrowthModelMedium()
    {
        return GrowthModelMedium;
    }

    public GameObject GetGrowthModelFinished()
    {
        return GrowthModelFinished;
    }

    public GameObject GetGrowthModelWithered()
    {
        return GrowthModelWithered;
    }

    public GameObject GetHandModel()
    {
        return HandModel;
    }

    public Item GetItem()
    {
        return this;
    }
    
    public int GetNumberOfItems()
    {
        return NumberOfItems;
    }

    public Item GetFinishedPlant()
    {
        return FinishedPlant;
    }

    #endregion

    public void SetNumberOfItems(int _Amount)
    {
        NumberOfItems = _Amount;
    }
    public void ChangeNumberOfItemsBy(int _AmountToChange)
    {
        NumberOfItems += _AmountToChange;
    }

    public virtual void UseItem()
    {

    }
}
