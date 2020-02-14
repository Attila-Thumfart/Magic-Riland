using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SwitchScenes : MonoBehaviour
{
    private GameObject player;          //player to check against

    [SerializeField]
    private Vector3 TargetPosition;     //position the player will get set to
    [SerializeField]
    private string TargetScene;         //scene the player will get teleported

    private GameObject animator;        //animator to call fade out

    private IEnumerator Coroutine(int _TimeToWait, Action _callback)        //coroutine to freeze the game while transitioning
    {
        yield return new WaitForSecondsRealtime(_TimeToWait);               //time to wait that the function gets
        _callback?.Invoke();                                                //action to execute after the waiting time
    }


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");            //finds the player in the scene
        animator = GameObject.Find("FadeManager");                      //finds the Animator for fading
    }

    private void OnTriggerEnter(Collider other)                         //if something hits the collider of the game object this script is attached to
    {
        if (other.tag == "Player")                                      //if this is a player
        {
            player.GetComponent<PlayerMovement>().enabled = false;      //disables player movement
            animator.GetComponent<FadingManager>().SetFade(true);       //calls the FadeManager to fade out
            StartCoroutine(Coroutine(1, () =>                           //Lambda function that gets called after 1 second
            {
                SceneManager.LoadScene(TargetScene);                                        //Loads the target scene
                player.GetComponent<PlayerMovement>().SetPlayerPosition(TargetPosition);    //sets the player to the target position
                animator.GetComponent<FadingManager>().SetFade(false);                      //fades out
                player.GetComponent<PlayerMovement>().enabled = true;                       //enables the playermovement again
            }));
        }
    }
}
