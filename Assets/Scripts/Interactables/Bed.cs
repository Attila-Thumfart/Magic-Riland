using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactable
{
    private GameObject animator;
    private GameObject EndOfDayCardUI;

    public override void Interact()
    {
        animator = GameObject.FindGameObjectWithTag("Animator");

        GameManager.GMInstance.IncrementCalenderDay();      //end the day 

        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<PlayerActions>().enabled = false;

        animator.GetComponent<FadingManager>().SetFade(true);
    }

    private void OnEnable()
    {
        EndOfDayCardUI = GameObject.Find("EndOfDayCard");
        EndOfDayCardUI.SetActive(false);
    }
}
