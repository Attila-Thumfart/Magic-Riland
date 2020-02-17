using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolkenActions : MonoBehaviour
{
    // public GameObject cloud;
    // public GameObject player;
    // public GameObject mainCam;
    // public GameObject cloudCam;

    private float cloudDuration;

    [SerializeField]
    private float maxCloudChannelDuration;

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
        cloudDuration -= Time.deltaTime;  // Counts down the duration of the cloud

        if (cloudDuration <= 0f)  //If the countdown reaches 0 the spell is cancled
        {
            CancleSpell();
        }
    }

    private void OnTriggerEnter(Collider other)         //checks if the Player touches a Field
    {
        if (other.tag == "Field")
        {
            Debug.Log("Watering Field");
            IsOnField = true;                           //sets the bool for it to true
            CurrentField = other.gameObject;            //references the current field; used for SeedField to know which field is seeded

            if (IsOnField)  //If the cloud is above a field it is watered
            {
                
                CurrentField.GetComponent<FieldManager>().SetIsWatered(true);
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

    private void CancleSpell()
    {
        Destroy(this.gameObject);
        Camera = GameObject.Find("CameraHolder");
        Camera.GetComponent<ObjectFollower>().enabled = true;
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
}
