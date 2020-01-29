using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolkenActions : MonoBehaviour
{
    PlayerControls controls; // This is where the Controls and actual Input are saved (via Unity Input System)

    public GameObject cloud;
    // public GameObject player;
    // public GameObject mainCam;
    // public GameObject cloudCam;

    private float cloudDuration;

    [SerializeField]
    private float maxCloudChannelDuration;

    // private float countdown;

    private bool IsOnField = false;
    GameObject CurrentField;

    private void Awake()
    {
        controls = new PlayerControls();  //enables the controls from the Unity Action Input System

       // countdown = cloudDuration;

     //   controls.Gameplay.Wasser.performed += ctx => CancleSpell();
    }

    private void Update()
    {
        cloudDuration -= Time.deltaTime;  // Counts down the duration of the cloud

        if (cloudDuration <= 0f)  //If the countdown reaches 0 the spell is cancled
        {
            CancleSpell();
        }

        if(IsOnField)  //If the cloud is above a field it is watered
        {
            CurrentField.GetComponent<FieldManager>().SetIsWatered(true);
        }
    }

    private void OnTriggerEnter(Collider other)         //checks if the Player touches a Field
    {
        if (other.tag == "Field")
        {
            IsOnField = true;                           //sets the bool for it to true
            CurrentField = other.gameObject;            //references the current field; used for SeedField to know which field is seeded

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

    private void CancleSpell()
    {
        cloud.SetActive(false);
        //cloudCam.SetActive(false);
        //player.GetComponent<ControllerMovement>().enabled = true;
        //mainCam.SetActive(true);
        //countdown = cloudDuration;
    }

    public void SetCloudDuration(float _duration)  //Simple Setter for the cloud duration
    {
        cloudDuration = _duration;
    }

    public float GetMaxCloudChannelDuration()  //Simple Getter for the Maximum Cloud Duration
    {
        return maxCloudChannelDuration;
    }

    private void OnEnable() // This function enables the controls when the object becomes enabled and active
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable() // This function disables the controls when the object becomes disabled or inactive
    {
        controls.Gameplay.Disable();
    }
}
