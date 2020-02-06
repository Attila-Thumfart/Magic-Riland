using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySamplePlant : MonoBehaviour
{
    [SerializeField]
    private SamplePlant plant;

    void Start()
    {
        // plant = GameObject.Find("SampleStrawberry");
    }
    private void Update()
    {

    }

    public int GetGrowthRateMedium()            //gives growthrateinformation to the field        
    {
        return plant.GetGrowthRateMedium();
    }

    public int GetGrowthRateFinished()          //gives growthrateinformation to the field
    {
        return plant.GetGrowthRateFinished();
    }
    public GameObject GetPlantMedium()
    {
        return plant.GetPlantMeshMedium();
    }

    public GameObject GetPlantFinished()
    {
        return plant.GetPlantMeshFinished();
    }

    public Item GetFinishedItem()
    {
        return plant.GetFinishedItem();
    }

}
