using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySamplePlant : MonoBehaviour
{
    [SerializeField]
    private SamplePlant plant;

    void Start()
    {
        
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
}
