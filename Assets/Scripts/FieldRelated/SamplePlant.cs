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
    private MeshRenderer PlantModel;
    [SerializeField]
    private GameObject GrowthModelFinished;
    [SerializeField]
    private GameObject GrowthModelMedium;
    [SerializeField]
    private Sprite Art;

    [SerializeField]
    private int GrowtRateMedium;
    [SerializeField]
    private int GrowthRateFinish;

    [SerializeField]
    private int SellPrice;

    private Item FinishedItem;


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

    public GameObject GetPlantMeshMedium()
    {
        return GrowthModelMedium;
    }

    public GameObject GetPlantMeshFinished()
    {
        return GrowthModelFinished;
    }

    public Item GetFinishedItem()
    {
        return FinishedItem;
    }


    public (string _PlantName, int _GrowthRateSmall, int _GrowthRateFinish) GetPlantInfos()     //??
    {
        return (PlantName, GrowtRateMedium, GrowthRateFinish);
    }
}
