using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : Interactable
{
    public enum Fieldstate             //different fieldstates
    {
        empty,
        seeded,
        sprout,
        medium,
        finished,
        withered,
    }
    private Fieldstate ActiveFieldstate = Fieldstate.empty;     //all Fields are empty at the start


    private int DayOfProgress;
    private int DaysUntilWithered = 3;

    [SerializeField]
    private GameObject FieldDry, FieldWatered;
    [SerializeField]
    private bool IsSeeded = false;
    [SerializeField]
    private bool IsWatered = false;


    private Item ThisPlant;

    private int GrowthRateUntilSprout;
    private int GrowthRateUntilMedium;
    private int GrowthRateUntilFinished;

    private GameObject GrowthModelSeed;
    private GameObject GrowthModelSprout;
    private GameObject GrowthModelMedium;
    private GameObject GrowthModelFinished;
    private GameObject GrowthModelWithered;

    private GameObject FieldDryInstance, FieldWateredInstance;
    private GameObject GrowthModelSeedInstance, GrowthModelSproutInstance, GrowthModelMediumInstance, GrowthModelFinishedInstance, GrowthModelWitheredInstance;




    public override void Start()
    {
        base.Start();
        FieldDryInstance = Instantiate(FieldDry, transform);
        FieldWateredInstance = Instantiate(FieldWatered, transform);
        GetComponent<MeshRenderer>().enabled = false;
        FieldDryInstance.SetActive(true);
        FieldWateredInstance.SetActive(false);
    }

    public override void Interact()
    {
        if (!IsSeeded)
        {
            SetIsSeeded(true);
            SetThisPlant(Player.GetComponent<PlayerActions>().GetCurrentItem());
        }

        if (IsSeeded && (ActiveFieldstate == Fieldstate.finished || ActiveFieldstate == Fieldstate.withered))
        {
            ResetField();
            if (ActiveFieldstate == Fieldstate.finished)
                GetThisPlant();
        }
    }

    void Update()
    {
        SwitchFields();
        WitheredField();
        Debug.Log(IsWatered);
        if (IsWatered)
        {
            FieldDryInstance.SetActive(false);
            FieldWateredInstance.SetActive(true);
        }
    }

    #region FIELD ROTATION
    private void SwitchFields()         //this switches the different states of the Field (Enums)
    {
        switch (ActiveFieldstate)
        {
            case (Fieldstate.empty):                                        //if this field is empty   
                if (IsSeeded)                                               //if the player seeded the field
                {
                    ActiveFieldstate = Fieldstate.seeded;                   //the field is now seeded
                    DayOfProgress = 0;
                }
                break;

            case (Fieldstate.seeded):                                       //if the plant is seeded
                GrowthModelSeedInstance.SetActive(true);

                if (DayOfProgress == GrowthRateUntilSprout)                                     //and if the day is ended (only for the first step from seed --> sprout)
                {
                    ActiveFieldstate = Fieldstate.sprout;                   //the seed growths into a sprout
                    DayOfProgress = 0;                                      //reset the progresstimer
                }
                break;

            case (Fieldstate.sprout):                                       //if the plant is a sprout
                GrowthModelSeedInstance.SetActive(false);
                GrowthModelSproutInstance.SetActive(true);

                if (DayOfProgress == GrowthRateUntilMedium)                      //and if the DayOfProgress matches the GrowthRateMedium step of the plant
                {
                    ActiveFieldstate = Fieldstate.medium;                   //the plant reaches its 2nd stage of its growthcycle
                    DayOfProgress = 0;                                      //reset the progresstimer
                }
                break;

            case (Fieldstate.medium):                                       //if the plant is on its medium state
                GrowthModelSproutInstance.SetActive(false);
                GrowthModelMediumInstance.SetActive(true);

                if (DayOfProgress == GrowthRateUntilFinished)                    //and if the DayOfProgress matches the GrowthRateFinished step of the plant
                {
                    ActiveFieldstate = Fieldstate.finished;                 //the plant is fully grown and ready to be harvested
                    DayOfProgress = 0;                                      //reset the progresstimer
                }
                break;

            case (Fieldstate.finished):                                     //if the plant is fully grown
                GrowthModelMediumInstance.SetActive(false);
                GrowthModelFinishedInstance.SetActive(true);

                if (DayOfProgress == 3)                                      //and if 3 days are passed
                {
                    ActiveFieldstate = Fieldstate.withered;                 //the plant is withered 
                }
                break;

            case (Fieldstate.withered):
                GrowthModelSeedInstance.SetActive(false);
                GrowthModelSproutInstance.SetActive(false);
                GrowthModelMediumInstance.SetActive(false);
                GrowthModelFinishedInstance.SetActive(false);
                GrowthModelWitheredInstance.SetActive(true);

                //MediumPlant.SetActive(false);
                break;

        }
    }
    #endregion

    #region SETTER
    public void SetIsSeeded(bool _NewState)          //can get called by PlayerActions to seed the field/empty the field
    {
        IsSeeded = _NewState;
        DaysUntilWithered = 3;
    }
    public void SetIsWatered(bool _NewState)               //setter for other scripts to set the watered state of the field
    {
        IsWatered = _NewState;
    }
    public void SetThisPlant(GameObject _PlayerFirstItem)
    {
        ThisPlant = _PlayerFirstItem.GetComponent<Strawberry>().GetItem();

        GrowthRateUntilSprout = ThisPlant.GetGrowthRateUntilSprout();
        GrowthRateUntilMedium = ThisPlant.GetGrowthRateUntilMedium();
        GrowthRateUntilFinished = ThisPlant.GetGrowthRateUntilMedium();

        GrowthModelSeed = ThisPlant.GetGrowthModelSeed();
        GrowthModelSprout = ThisPlant.GetGrowthModelSprout();
        GrowthModelMedium = ThisPlant.GetGrowthModelMedium();
        GrowthModelFinished = ThisPlant.GetGrowthModelFinished();
        GrowthModelWithered = ThisPlant.GetGrowthModelWithered();

        GrowthModelSeedInstance = Instantiate(GrowthModelSeed, transform);
        GrowthModelSproutInstance = Instantiate(GrowthModelSprout, transform);
        GrowthModelMediumInstance = Instantiate(GrowthModelMedium, transform);
        GrowthModelFinishedInstance = Instantiate(GrowthModelFinished, transform);
        GrowthModelWitheredInstance = Instantiate(GrowthModelWithered, transform);

        GrowthModelSeedInstance.SetActive(false);
        GrowthModelSproutInstance.SetActive(false);
        GrowthModelMediumInstance.SetActive(false);
        GrowthModelFinishedInstance.SetActive(false);
        GrowthModelWitheredInstance.SetActive(false);
    }
    #endregion


    public void UpdateFieldDays()                   //does the logic behind the daily cycling of the stages, gets called every day from GameManager
    {
        if (IsWatered)                              //if the field is watered
        {
            IsWatered = false;                      //dry out the field again
            FieldDryInstance.SetActive(true);
            FieldWateredInstance.SetActive(false);
            DayOfProgress++;                        //the plant growths towards its next step
        }
        else if (!IsWatered && IsSeeded)            //if the field is not waterd but seeded
        {
            DaysUntilWithered--;                    //the plant is one step closer to dry out
        }
    }

    public void ResetField()                                //resets the field to an empty state
    {
        ActiveFieldstate = Fieldstate.empty;
    }

    private void WitheredField()                            //if the plant is not watered for 3 days this function is called and "kills" the plant
    {
        if (DaysUntilWithered == 0)
        {
            ActiveFieldstate = Fieldstate.withered;
        }
    }

    public Item GetThisPlant()
    {
        return ThisPlant;
    }

    public Fieldstate GetFieldstate()                       //getter for other scripts to get the active Fieldstate
    {
        return ActiveFieldstate;
    }
}
