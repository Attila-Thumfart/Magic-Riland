using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySamplePlant : MonoBehaviour
{

    [SerializeField]
    private SamplePlant Plant;


    void Start()
    {
        //Plant = Get
        Plant.Print();
    }

    public SamplePlant GetPlant()
    {
        return Plant;
    }
    
}
