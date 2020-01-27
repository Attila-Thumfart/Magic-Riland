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


    public void PrintInformation()
    {
        Debug.Log(PlantName + ": " + Description + ". You can sell it for " + SellPrice);
    }

    public int GetGrowthRateMedium()        //Used for instances of the Plant to give Information to the Field
    {
        return GrowtRateMedium;
    }
    public int GetGrowthRateFinished()      //Used for instances of the Plant to give Information to the Field
    {
        return GrowthRateFinish;
    }
    

    public (string _PlantName, int _GrowthRateSmall, int _GrowthRateFinish) GetPlantInfos()     //??
    {
        return (PlantName, GrowtRateMedium, GrowthRateFinish);
    }
}
