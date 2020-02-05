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
    private GameObject GrowthModelFinished;     //this stores the Finished plant as a GameObject
    [SerializeField]
    private GameObject GrowthModelMedium;       //this stores the Finished plant as a GameObject
    [SerializeField]
    private GameObject GrowthModelSprout;       //this stores the Finished plant as a GameObject
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

    public GameObject GetPlantMeshMedium()
    {
        return GrowthModelMedium;
    }

    public GameObject GetPlantMeshFinished()
    {
        return GrowthModelFinished;
    }
}
