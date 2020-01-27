using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GMInstance;   //an instance for other scripts to call functions from GM


    [SerializeField]
    private int CalenderDay = 1;            //the days passing in a playthrough

    [SerializeField]
    private bool isNight;                   //for checks if its Day or Night



    public void Awake()
    {
        GMInstance = this;
    }

    private void Update()
    {
        IncrementCalenderDay();
        EndNight();
    }


    public void IncrementCalenderDay()                       //Incrementer for other scripts to call an update of CalenderDay
    {
        if (Input.GetKeyDown("space") && !isNight)           //HAS TO BE CHANGED! Later: if player goes to sleep
        {
            isNight = true;
            CalenderDay++;
        }
    }

    public int GetCalenderDay()                             //getter for other scripts to read CalenderDay
    {
        return CalenderDay;
    }

    private void EndNight()
    {
        if (Input.GetKeyDown("q") && isNight)
        {
            isNight = false;
        }
    }

}
