using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerActions : MonoBehaviour
{
    private bool IsOnField = false;
    GameObject CurrentField;
    GameObject CurrentItem;

    public GameObject cloud;
    public GameObject player;

    private bool channelState = false;
    private float cloudDuration;
    private float maxCloudDuration;

    // public GameObject mainCam;
    // public GameObject cloudCam;

    PlayerControls controls; // This is where the Controls and actual Input are saved (via Unity Input System)

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Interact.performed += ctx => SeedField();
        controls.Gameplay.Wasser.started += ctx => StartChannel();
        controls.Gameplay.Wasser.canceled += ctx => EndChannel();
    }


    private void FixedUpdate()
    {
        ChannelCounter();
        Debug.Log(cloudDuration);
    }


    private void StartChannel()
    {
        Debug.Log("StartedChannel");

        if (cloud.activeSelf == false)
        {
            WolkenActions myCloud = cloud.GetComponent<WolkenActions>();
            maxCloudDuration = myCloud.GetMaxCloudChannelDuration();

            channelState = true;
        }
    }

    private void EndChannel()
    {
        if (cloudDuration < 1f)
        {
            Debug.Log("EndWithoutCloud");
            channelState = false;
            cloudDuration = 0f;
        }
        else if (cloudDuration >= 1f)
        {
            Debug.Log("EndWithCloud");
            channelState = false;
            waterSpell(cloudDuration * 2);
            Debug.Log("waterSpell activated");
            cloudDuration = 0f;
            Debug.Log("CounterSet0");
        }
    }

    private void ChannelCounter()
    {
        if (channelState)
        {
            cloudDuration += Time.deltaTime;
        }

        if (channelState && cloudDuration >= maxCloudDuration)
        {
            channelState = false;
            cloudDuration = maxCloudDuration;
            EndChannel();
        }
    }

    //state true
    //if true
    // counter = deltatime

    //on cancle
    //if counter < 1 ---> state false, counter 0
    //if counter > 1 ---> state false, waterspell + channle duration *2, counter 0
    //


    private void waterSpell(float _duration)
    {
        cloud.transform.position = player.transform.position;
        //cloudCam.transform.position = mainCam.transform.position;

        WolkenActions myCloud = cloud.GetComponent<WolkenActions>();
        myCloud.SetCloudDuration(_duration);

        Debug.Log("Duration Set");

        cloud.SetActive(true);

        // cloudCam.SetActive(true);
        // player.GetComponent<ControllerMovement>().enabled = false;
        // mainCam.SetActive(false);
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

    void SeedField()                                    //Seeds the field and gives over the plants information
    {
        if (IsOnField)
        {
            CurrentItem = FindObjectOfType<MySamplePlant>().gameObject;  //Later: first item in inventory

            CurrentField.GetComponent<FieldManager>().SetIsSeeded(true);
            CurrentField.GetComponent<FieldManager>().SetGrowthrates(CurrentItem);
        }
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
