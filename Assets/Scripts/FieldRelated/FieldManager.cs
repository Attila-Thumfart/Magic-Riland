using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager GM;
    GameObject Player;

    [SerializeField]
    private enum Fieldstate
    {
        empty,
        seeded,
        sprout,
        growing,
        finished,
        withered
    }

    [SerializeField]
    private Fieldstate ActiveFieldState = Fieldstate.empty;

    [SerializeField]
    private int SeedDay;
    [SerializeField]
    private int GrowthRateMedium;
    [SerializeField]
    private int GrowthRateFinished;

    [SerializeField]
    private bool IsSeeded = false;
    [SerializeField]
    private bool IsWatered = false;


    private void Start()
    {
        GM = GameManager.GMInstance;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        SwitchFields();
    }

    private void SwitchFields()
    {
        switch (ActiveFieldState)
        {
            case (Fieldstate.empty):
                if(IsSeeded)
                {
                    ActiveFieldState = Fieldstate.seeded;
                    SeedDay = GameManager.GMInstance.GetCalenderDay();
                }
                break;
            case (Fieldstate.seeded):
                break;
            case (Fieldstate.sprout):
                break;
            case (Fieldstate.growing):
                break;
            case (Fieldstate.finished):
                break;
            case (Fieldstate.withered):
                break;

        }
    }


    public void SetIsSeeded(bool NewState)
    {
        IsSeeded = NewState;
      //  GrowthRateMedium = 
    }

    public void SetGrowthrates(GameObject _MySamplePlant)
    {
        GrowthRateMedium = _MySamplePlant.GetComponent<MySamplePlant>().GetPlant().GetGrowthRateMedium();
        GrowthRateFinished = _MySamplePlant.GetComponent<MySamplePlant>().GetPlant().GetGrowthRateFinish();
    }



    public void ResetField()
    {
        IsSeeded = false;
    }
}
