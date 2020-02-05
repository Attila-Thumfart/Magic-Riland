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
    private int DayOfProgress;
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

    private GameObject MediumPlant;
    private GameObject MyMediumPlant;

    private GameObject FinishedPlant;

    


    private void Start()
    {
        MyMediumPlant = GameObject.Find("MyMediumPlant");
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

                    ActiveFieldstate = Fieldstate.seeded;                   //the field is now seeded
                    SeedDay = GameManager.GMInstance.GetCalenderDay();      //remember what day the seeding has taken place
                    DayOfProgress = 0;
                }
                break;

            case (Fieldstate.seeded):                                       //if the plant is seeded
                if (DayOfProgress == 1)                                     //and if the day is ended (only for the first step from seed --> sprout)
                {
                    ActiveFieldstate = Fieldstate.sprout;                   //the seed growths into a sprout
                    DayOfProgress = 0;                                      //reset the progresstimer
                }
                break;

            case (Fieldstate.sprout):                                       //if the plant is a sprout
                if (DayOfProgress == GrowthRateMedium)                      //and if the DayOfProgress matches the GrowthRateMedium step of the plant
                {

                    ActiveFieldstate = Fieldstate.medium;                   //the plant reaches its 2nd stage of its growthcycle
                    DayOfProgress = 0;                                      //reset the progresstimer
                }
                break;

            case (Fieldstate.medium):                                       //if the plant is on its medium state 
                
                MediumPlant.SetActive(true);
                GetComponent<MeshRenderer>().enabled = false;

                if (DayOfProgress == GrowthRateFinished)                    //and if the DayOfProgress matches the GrowthRateFinished step of the plant
                {  
                    ActiveFieldstate = Fieldstate.finished;                 //the plant is fully grown and ready to be harvested
                    DayOfProgress = 0;                                      //reset the progresstimer
                }
                break;

            case (Fieldstate.finished):                                     //if the plant is fully grown
                MediumPlant.SetActive(false);
                FinishedPlant.SetActive(true);

                if (DayOfProgress == 3)                                      //and if 3 days are passed
                {
                    ActiveFieldstate = Fieldstate.withered;                 //the plant is withered 
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

    public void UpdateFieldDays()                   //does the logic behind the daily cycling of the stages, gets called every day from GameManager
    {
        if (IsWatered)                              //if the field is watered
        {
            DayOfProgress++;                        //the plant growths towards its next step
            IsWatered = false;                      //dry out the field again
        }
        else if (!IsWatered && IsSeeded)            //if the field is not waterd but seeded
        {
            DaysUntilWithered--;                    //the plant is one step closer to dry out
        }
    }

    public void SetGrowthrates(GameObject _MySamplePlant)           //gets informations of MySamplePlant to the field
    {
        GrowthRateMedium = _MySamplePlant.GetComponent<MySamplePlant>().GetGrowthRateMedium();          //growthrate to first state
        GrowthRateFinished = _MySamplePlant.GetComponent<MySamplePlant>().GetGrowthRateFinished();      //growthrate to finished state
    }

    public void SetMeshes(GameObject _MySamplePlant)
    {
        MediumPlant = Instantiate(_MySamplePlant.GetComponent<MySamplePlant>().GetPlantMedium(), transform);
        MediumPlant.SetActive(false);

        FinishedPlant = Instantiate(_MySamplePlant.GetComponent<MySamplePlant>().GetPlantFinished(), transform);
        FinishedPlant.SetActive(false);
    }

    public void SetIsWatered(bool _NewState)               //setter for other scripts to set the watered state of the field
    {
        IsWatered = _NewState;
    }


    public void ResetField()                                //resets the field to an empty state
    {
        Destroy(MediumPlant);
        Destroy(FinishedPlant);
        GetComponent<MeshRenderer>().enabled = true;
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


    public Fieldstate GetFieldstate()                       //getter for other scripts to get the active Fieldstate
    {
        return ActiveFieldstate;
    }
}
