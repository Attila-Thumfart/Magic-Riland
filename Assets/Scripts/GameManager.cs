using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GMInstance;   //an instance for other scripts to call functions from GM

    private GameObject animator;
    private GameObject Player;                                  //used to find the Player
    List<FieldManager> Fields = new List<FieldManager>();       //makes a List containing all "FieldManagers"

    [SerializeField]
    private int PlayerMoney;
    private int DailyIncome;

    [SerializeField]
    private int CalenderDay = 1;            //the days passing in a playthrough

    [SerializeField]
    private GameObject EndOfDayCardUI;      //Used to show the summary of the end of each day

    public void Awake()
    {
        DefineGameObjects();                //every Game Object the GM needs gets defined there

        EndOfDayCardUI.SetActive(false);    //the scene gets faded in

        DailyIncome = 0;
        PlayerMoney = 0;
    }


    public void IncrementCalenderDay()                       //Incrementer for other scripts to call an update of CalenderDay
    {
        CalenderDay++;
        StartCoroutine(Coroutine(1.2f, () =>                //Lambda fuunction: waits 1.2 seconds before continuing with the following code
        {
            AddDailyIncomeToPlayerMoney();
            EndOfDayCardUI.SetActive(true);                 //shows the summary at the end of the day
            EndOfDayCardUI.GetComponent<EndOfDayUI>().UpdateEndOFDayUI();
            ResetDailyIncome();
        }));
    }

    private IEnumerator Coroutine(float _TimeToWait, Action _callback)      //used to wait a set number of seconds for the code to continue
    {
        yield return new WaitForSecondsRealtime(_TimeToWait);               //waiting for the given time in seconds
        _callback?.Invoke();                                                //actions that get called after the set time
    }

    public int GetCalenderDay()                             //getter for other scripts to read CalenderDay
    {
        return CalenderDay;
    }

    public void EndNight()                                      //gets called after closing the summary of the day to end the night
    {
        FindObjectOfType<DontDestroyFields>().transform.GetChild(0).gameObject.SetActive(true);

        Fields.Clear();                                                                         //clears all fields from the list to not get double entries
        foreach (FieldManager go in FieldManager.FindObjectsOfType(typeof(FieldManager)))       //finds all objects of type FieldManager
        {
            if (go.tag == "Field")                                                              //if the Tag of this object is "Field"
            {
                Fields.Add(go);                                                                 //add it to the List of Fields
            }
        }

        EndOfDayCardUI.SetActive(false);                                //Removes the summary of the previous day
        Player = GameObject.Find("Player");                             //Finds the Player

        StartCoroutine(Coroutine(0.2f, () =>                            //Lambda function: waits for 0.2 seconds before executing the following code (emergency solution to quick-fix a bug)
       {
           Player.GetComponent<PlayerMovement>().enabled = true;       //Enables the Movement of the player when ending the night
           Player.GetComponent<PlayerActions>().enabled = true;
       }));

        animator.GetComponent<FadingManager>().SetFade(false);          //Fades in after the night

        for (int i = 0; i < Fields.Count; i++)                          //every field in the scene
        {
            Fields[i].UpdateFieldDays();                                //update their status (happens in FieldManager)
            int WeedChance = UnityEngine.Random.Range(1, 10);
            if (WeedChance == 1)
            {
                Fields[i].SetWeedstate(true);

                Debug.Log("Field " + Fields[i] + " is weeded");
            }
        }
        FindObjectOfType<DontDestroyFields>().transform.GetChild(0).gameObject.SetActive(false);
    }

    public void AddDailyIncome(int _money)
    {
        DailyIncome += _money;
    }

    public void AddDailyIncomeToPlayerMoney()
    {
        PlayerMoney += DailyIncome;
    }

    public void ResetDailyIncome()
    {
        DailyIncome = 0;
    }

    public bool RemovePlayerMoney(int _price)
    {
        if (PlayerMoney - _price >= 0)
        {
            PlayerMoney -= _price;
            return true;
        }
        else
        {
            Debug.Log("Not enough money");
            return false;
        }
    }

    public int GetPlayerMoney()
    {
        return PlayerMoney;
    }

    public int GetDailyIncome()
    {
        return DailyIncome;
    }

    private void DefineGameObjects()
    {
        if (GMInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        GMInstance = this;

        DontDestroyOnLoad(this);                    //the GM does not get destroyed when a new scene is loaded in

        animator = GameObject.Find("FadeManager");  //Set the Animator to use fading effects
    }
}
