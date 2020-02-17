using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactable
{
    private GameObject animator;        //creates an animator 

    public override void Interact()
    {
        animator = GameObject.Find("FadeManager");  //Set the Animator to use fading effects 

        GameManager.GMInstance.IncrementCalenderDay();      //calls the GM to end the day

        Player.GetComponent<PlayerMovement>().enabled = false;      //disables PlayerMovement
        Player.GetComponent<PlayerActions>().enabled = false;       //disables PlayerActions

        animator.GetComponent<FadingManager>().SetFade(true);       //fades out
    }
}
