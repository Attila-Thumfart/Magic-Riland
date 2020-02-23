using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : Interactable
{
    public enum Fieldstate             //different fieldstates
    {
        notThere,
        empty,
        seeded,
        sprout,
        medium,
        finished,
        withered,
    }
    [SerializeField]
    private Fieldstate ActiveFieldstate = Fieldstate.empty;     //all Fields are empty at the start


    private int DayOfProgress;
    private int DaysUntilWithered = 3;

    [SerializeField]
    private GameObject FieldDry, FieldWatered;
    private bool IsSeeded = false;
    private bool IsWatered = false;
    [SerializeField]
    private bool IsPlowed = false;

    private Item ThisPlant;
    private Item ThisFinishedPlant;

    private int GrowthRateUntilSprout;
    private int GrowthRateUntilMedium;
    private int GrowthRateUntilFinished;

    [SerializeField]
    private GameObject WeedModel;
    private GameObject WeedModelInstance;
    private bool isWeed;

    private GameObject GrowthModelSeed;
    private GameObject GrowthModelSprout;
    private GameObject GrowthModelMedium;
    private GameObject GrowthModelFinished;
    private GameObject GrowthModelWithered;

    private GameObject FieldDryInstance, FieldWateredInstance;
    private GameObject GrowthModelSeedInstance, GrowthModelSproutInstance, GrowthModelMediumInstance, GrowthModelFinishedInstance, GrowthModelWitheredInstance;

    private Inventory inventory;


    public override void Start()
    {
        base.Start();
        FieldDryInstance = Instantiate(FieldDry, transform);
        FieldWateredInstance = Instantiate(FieldWatered, transform);
        GetComponent<MeshRenderer>().enabled = false;
        FieldDryInstance.SetActive(false);
        FieldWateredInstance.SetActive(false);
    }

    public override void Interact()
    {
        inventory = Inventory.instance;

        if (!IsSeeded && ActiveFieldstate == Fieldstate.empty)
        {
            ThisPlant = Player.GetComponent<PlayerActions>().GetCurrentItem();
            if (ThisPlant != null)
            {
                if (ThisPlant.GetIsSeed())
                {
                    SetThisPlant(ThisPlant);
                    SetIsSeeded(true);
                    inventory.RemoveItemFromInventory(inventory.GetCurrentItemIndex());
                }
            }
        }

        if (IsSeeded && (ActiveFieldstate == Fieldstate.finished || ActiveFieldstate == Fieldstate.withered))
        {
            if (ActiveFieldstate == Fieldstate.finished)
            {
                inventory.AddItemToInventory(GetThisPlant());
            }
            ResetField();
        }
    }

    void Update()
    {
        SwitchFields();
        WitheredField();
        if (IsWatered)
        {
            FieldDryInstance.SetActive(false);
            FieldWateredInstance.SetActive(true);
        }
        if(!IsPlowed)
        {
            ActiveFieldstate = Fieldstate.notThere;
            FieldDryInstance.SetActive(false);
            FieldWateredInstance.SetActive(false);
        }
    }

    #region FIELD ROTATION
    private void SwitchFields()         //this switches the different states of the Field (Enums)
    {
        switch (ActiveFieldstate)
        {
            case (Fieldstate.notThere):
                if (IsPlowed)
                {
                    FieldDryInstance.SetActive(true);
                    ActiveFieldstate = Fieldstate.empty;
                }
                break;

            case (Fieldstate.empty):                                        //if this field is empty   
                if (IsSeeded)                                               //if the player seeded the field
                {
                    ActiveFieldstate = Fieldstate.seeded;                   //the field is now seeded
                    DayOfProgress = 0;
                }
                break;

            case (Fieldstate.seeded):                                       //if the plant is seeded
                GrowthModelSeedInstance.SetActive(true);

                if (DayOfProgress == GrowthRateUntilSprout)                 //and if the day is ended (only for the first step from seed --> sprout)
                {
                    ActiveFieldstate = Fieldstate.sprout;                   //the seed growths into a sprout
                    DayOfProgress = 0;                                      //reset the progresstimer
                }
                break;

            case (Fieldstate.sprout):                                       //if the plant is a sprout
                GrowthModelSeedInstance.SetActive(false);
                GrowthModelSproutInstance.SetActive(true);

                if (DayOfProgress == GrowthRateUntilMedium)                 //and if the DayOfProgress matches the GrowthRateMedium step of the plant
                {
                    ActiveFieldstate = Fieldstate.medium;                   //the plant reaches its 2nd stage of its growthcycle
                    DayOfProgress = 0;                                      //reset the progresstimer
                }
                break;

            case (Fieldstate.medium):                                       //if the plant is on its medium state
                GrowthModelSproutInstance.SetActive(false);
                GrowthModelMediumInstance.SetActive(true);

                if (DayOfProgress == GrowthRateUntilFinished)               //and if the DayOfProgress matches the GrowthRateFinished step of the plant
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
                    ActiveFieldstate = Fieldstate.withered;                  //the plant is withered 
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

    public void SetIsPlowed(bool _NewState)
    {
        IsPlowed = _NewState;
        if(_NewState)
        {
            FieldDryInstance.SetActive(true);
        }
        else if(!_NewState)
        {
            ActiveFieldstate = Fieldstate.notThere;
            FieldDryInstance.SetActive(false);
            FieldWateredInstance.SetActive(false);
        }
    }

    public void SetWeedstate(bool _NewState)
    {
        isWeed = _NewState;
        if (_NewState)
        {
            WeedModelInstance = Instantiate(WeedModel, transform);
            WeedModelInstance.SetActive(_NewState);
        }
        else if(!_NewState)
        {
            Destroy(WeedModelInstance);
        }
    }
    public void SetThisPlant(Item _PlayerFirstItem)
    {
        GrowthRateUntilSprout = ThisPlant.GetGrowthRateUntilSprout();
        GrowthRateUntilMedium = ThisPlant.GetGrowthRateUntilMedium();
        GrowthRateUntilFinished = ThisPlant.GetGrowthRateUntilMedium();

        GrowthModelSeed = ThisPlant.GetGrowthModelSeed();
        GrowthModelSprout = ThisPlant.GetGrowthModelSprout();
        GrowthModelMedium = ThisPlant.GetGrowthModelMedium();
        GrowthModelFinished = ThisPlant.GetGrowthModelFinished();
        GrowthModelWithered = ThisPlant.GetGrowthModelWithered();

        ThisFinishedPlant = ThisPlant.GetFinishedPlant();

        GrowthModelSeedInstance = Instantiate(GrowthModelSeed, transform);
        GrowthModelSproutInstance = Instantiate(GrowthModelSprout, transform);
        GrowthModelMediumInstance = Instantiate(GrowthModelMedium, transform);
        GrowthModelFinishedInstance = Instantiate(GrowthModelFinished, transform);
        GrowthModelWitheredInstance = Instantiate(GrowthModelWithered, transform);

        GrowthModelSeedInstance.SetActive(true);
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
        else if ((!IsWatered && IsSeeded) || (IsWatered && isWeed))            //if the field is not waterd but seeded
        {
            DaysUntilWithered--;                    //the plant is one step closer to dry out
        }
    }

    public void ResetField()                                //resets the field to an empty state
    {
        GrowthModelSeedInstance.SetActive(false);
        GrowthModelSproutInstance.SetActive(false);
        GrowthModelMediumInstance.SetActive(false);
        GrowthModelFinishedInstance.SetActive(false);
        GrowthModelWitheredInstance.SetActive(false);

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

    public Item GetThisPlant()
    {
        return ThisFinishedPlant;
    }

    public Fieldstate GetFieldstate()                       //getter for other scripts to get the active Fieldstate
    {
        return ActiveFieldstate;
    }
}
