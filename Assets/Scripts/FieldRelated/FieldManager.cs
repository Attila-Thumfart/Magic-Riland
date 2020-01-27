using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    
    GameManager GM;                     //used to use the GameManager
    GameObject Player;                  //used to use informations of the Player

    [SerializeField]
    private enum Fieldstate             //different fieldstates
    {
        empty,
        seeded,
        sprout,
        growing,
        finished,
        withered
    }

    [SerializeField]
    private Fieldstate ActiveFieldState = Fieldstate.empty;     //all Fields are empty at the start

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
        GM = GameManager.GMInstance;                                    //finds the GM
        Player = GameObject.FindGameObjectWithTag("Player");            //finds the Player
    }

    void Update()
    {
        SwitchFields();
    }

    private void SwitchFields()         //this switches the different states of the Field (Enums)
    {
        switch (ActiveFieldState)
        {
            case (Fieldstate.empty):                                        //if this field is empty
                if(IsSeeded)                                                //if the player seeded the field
                {
                    ActiveFieldState = Fieldstate.seeded;                   //switch the state of the Field to seeded
                    SeedDay = GameManager.GMInstance.GetCalenderDay();      //remember what day the seeding has taken place
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


    public void SetIsSeeded(bool NewState)          //can get called by PlayerActions to seed the field/empty the field
    {
        IsSeeded = NewState;
    }

    public void SetGrowthrates(GameObject _MySamplePlant)           //gets informations of MySamplePlant to the field
    {
        GrowthRateMedium = _MySamplePlant.GetComponent<MySamplePlant>().GetGrowthRateMedium();          //growthrate to first state
        GrowthRateFinished = _MySamplePlant.GetComponent<MySamplePlant>().GetGrowthRateFinished();      //growthrate to finished state
    }



    public void ResetField()            //resets the field to an empty state
    {
        IsSeeded = false;
        ActiveFieldState = Fieldstate.empty;
    }
}
