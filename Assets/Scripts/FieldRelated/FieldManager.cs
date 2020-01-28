using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{

    GameManager GM;                     //used to use the GameManager
    GameObject Player;                  //used to use informations of the Player

    [SerializeField]
    public enum Fieldstate             //different fieldstates
    {
        empty,
        seeded,
        sprout,
        medium,
        finished,
        withered,
    }

    [SerializeField]
    private Fieldstate ActiveFieldstate = Fieldstate.empty;     //all Fields are empty at the start

    [SerializeField]
    private int SeedDay;
    [SerializeField]
    private int DaysUntilProgress;
    [SerializeField]
    private int DaysUntilWithered = 3;

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


        WitheredField();
    }

    private void SwitchFields()         //this switches the different states of the Field (Enums)
    {
        switch (ActiveFieldstate)
        {
            case (Fieldstate.empty):                                        //if this field is empty
                if (IsSeeded)                                               //if the player seeded the field
                {
                    ActiveFieldstate = Fieldstate.seeded;                   //switch the state of the Field to seeded
                    SeedDay = GameManager.GMInstance.GetCalenderDay();      //remember what day the seeding has taken place
                    DaysUntilProgress = 0;
                }
                break;

            case (Fieldstate.seeded):                                                                   //if the field is seeded
                if (DaysUntilProgress == 1)
                {
                    ActiveFieldstate = Fieldstate.sprout;
                    DaysUntilProgress = 0;
                }
                break;

            case (Fieldstate.sprout):
                if (DaysUntilProgress == GrowthRateMedium)
                {
                    DaysUntilProgress = 0;
                    ActiveFieldstate = Fieldstate.medium;
                }
                break;

            case (Fieldstate.medium):
                if (DaysUntilProgress == GrowthRateFinished)
                {
                    DaysUntilProgress = 0;
                    ActiveFieldstate = Fieldstate.finished;
                }
                break;

            case (Fieldstate.finished):
                if(DaysUntilProgress == 3)
                {
                    ActiveFieldstate = Fieldstate.withered;
                }
                break;

            case (Fieldstate.withered):
                break;

        }
    }


    public void SetIsSeeded(bool _NewState)          //can get called by PlayerActions to seed the field/empty the field
    {
        IsSeeded = _NewState;
    }

    public void UpdateFieldDays()
    {
        if (IsWatered)
        {
            DaysUntilProgress++;
            IsWatered = false;
        }
        else if (!IsWatered)
        {
            DaysUntilWithered--;
        }
    }

    public void SetGrowthrates(GameObject _MySamplePlant)           //gets informations of MySamplePlant to the field
    {
        GrowthRateMedium = _MySamplePlant.GetComponent<MySamplePlant>().GetGrowthRateMedium();          //growthrate to first state
        GrowthRateFinished = _MySamplePlant.GetComponent<MySamplePlant>().GetGrowthRateFinished();      //growthrate to finished state
    }

    public void SetIsWatered(bool _NewState)
    {
        IsWatered = _NewState;
    }


    public void ResetField()            //resets the field to an empty state
    {
        IsSeeded = false;
        ActiveFieldstate = Fieldstate.empty;
    }

    private void WitheredField()                            //if the plant is not watered for 3 days this function is called and "kills" the plant
    {
        if (DaysUntilWithered == 0)
        {
            ActiveFieldstate = Fieldstate.withered;
        }
    }


    public Fieldstate GetFieldstate()
    {
        return ActiveFieldstate;
    }
}
