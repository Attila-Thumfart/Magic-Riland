﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindActions : MonoBehaviour
{
 private float windDuration;

    [SerializeField]
    private float maxWindChannelDuration;

    // private float countdown;

    private bool IsOnField = false;
    GameObject CurrentField;
    private GameObject Camera;

    private void Awake()
    {
        // countdown = cloudDuration;

        //   controls.Gameplay.Wasser.performed += ctx => CancleSpell();
    }

    private void Update()
    {
        windDuration -= Time.deltaTime;  // Counts down the duration of the cloud

        if (windDuration <= 0f)  //If the countdown reaches 0 the spell is cancled
        {
            CancleSpell();
        }
    }

    private void OnTriggerEnter(Collider other)         //checks if the Player touches a Field
    {
        if (other.tag == "Field")
        {
            Debug.Log("Winding Field");
            IsOnField = true;                           //sets the bool for it to true
            CurrentField = other.gameObject;            //references the current field; used for SeedField to know which field is seeded

            if (IsOnField)  //If the cloud is above a field it is watered
            {    
                CurrentField.GetComponent<FieldManager>().SetWeedstate(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)          //checks if the Player stops touching a field
    {
        if (other.tag == "Field")
        {
            IsOnField = false;                          //sets the bool for it to false
            CurrentField = null;                        //dereferences the current field
        }
    }

    public void CancleSpell()
    {
        Destroy(gameObject);
        Camera = GameObject.Find("CameraHolder");
        Camera.GetComponent<ObjectFollower>().enabled = true;
        //cloudCam.SetActive(false);
        //player.GetComponent<ControllerMovement>().enabled = true;
        //mainCam.SetActive(true);
        //countdown = cloudDuration;
    }

    public void SetWindDuration(float _duration)  //Simple Setter for the cloud duration
    {
        windDuration = _duration;
    }

    public float GetMaxWindChannelDuration()  //Simple Getter for the Maximum Cloud Duration
    {
        return maxWindChannelDuration;
    }
}
