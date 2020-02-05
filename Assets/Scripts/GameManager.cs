﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager GMInstance;   //an instance for other scripts to call functions from GM

    private GameObject animator;
    private GameObject Player;                                  //used to find the Player
    List<FieldManager> Fields = new List<FieldManager>();       //makes a List containing all "FieldManagers"

    [SerializeField]
    private int CalenderDay = 1;            //the days passing in a playthrough

    [SerializeField]
    private bool isNight;                   //for checks if its Day or Night

    private GameObject EndOfDayCardUI;

    public void Awake()
    {
        DefineGameObjects();

        foreach (FieldManager go in FieldManager.FindObjectsOfType(typeof(FieldManager)))       //finds all objects of type FieldManager
        {
            if (go.tag == "Field")                                                              //if the Tag of this object is "Field"
                Fields.Add(go);                                                                 //add it to the List of Fields
        }
    }

    private void Start()
    {
        animator.GetComponent<FadingManager>().SetFade(false);
        EndOfDayCardUI = GameObject.Find("EndOfDayCard");
        EndOfDayCardUI.SetActive(false);
    }

    private void Update()
    {
        // IncrementCalenderDay();
       // EndNight();
    }


    public void IncrementCalenderDay()                       //Incrementer for other scripts to call an update of CalenderDay
    {
        isNight = true;
        CalenderDay++;
        StartCoroutine(Coroutine(1.2f, () =>
        {
            EndOfDayCardUI.SetActive(true);
        }));
    }

    private IEnumerator Coroutine(float _TimeToWait, Action _callback)
    {
        yield return new WaitForSecondsRealtime(_TimeToWait);
        _callback?.Invoke();

    }

    public int GetCalenderDay()                             //getter for other scripts to read CalenderDay
    {
        return CalenderDay;
    }

    public void EndNight()
    {
        if (isNight)                           //later: if player ends the night via a submenu
        {
            EndOfDayCardUI.SetActive(false);
            isNight = false;
            Player.GetComponent<PlayerActions>().EnableMovement();      //Enables the Movement of the player when ending the night
            animator.GetComponent<FadingManager>().SetFade(false);

            for (int i = 0; i < Fields.Count; i++)                      //every field in the scene
            {
                Fields[i].UpdateFieldDays();                            //update their status (happens in FieldManager)
            }
        }
    }


    private void DefineGameObjects()
    {
        animator = GameObject.Find("FadeManager");
        Player = GameObject.Find("Player");         //Finds the Player
        //DontDestroyOnLoad(Player);                  //Player wont get destroyed if a new scene is loading

        if (GMInstance == null)                     //this makes it so only one GM is loaded
        {
            GMInstance = this;                      //Defines the GM for other scripts to use
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

}
