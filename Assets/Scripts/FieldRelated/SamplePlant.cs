using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class SamplePlant : ScriptableObject
{
    [SerializeField]
    private string PlantName;
    [SerializeField]
    private string Description;

    [SerializeField]
    private Mesh PlantModel;
    [SerializeField]
    private Mesh GrowthModelSmall;
    [SerializeField]
    private Mesh GrowthModelMedium;
    [SerializeField]
    private Sprite Art;

    [SerializeField]
    private int GrowtRateMedium;
    [SerializeField]
    private int GrowthRateFinish;

    [SerializeField]
    private int SellPrice;


    public void Print()
    {
        Debug.Log(PlantName + ": " + Description + ". You can sell it for " + SellPrice);
    }

    public int GetGrowthRateMedium()
    {
        return GrowtRateMedium;
    }
    public int GetGrowthRateFinish()
    {
        return GrowthRateFinish;
    }
    

    public (string _PlantName, int _GrowthRateSmall, int _GrowthRateFinish) GetPlantInfos()
    {
        return (PlantName, GrowtRateMedium, GrowthRateFinish);
    }
}
