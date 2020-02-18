using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthActions : MonoBehaviour
{
    private float earthDuration;

    [SerializeField]
    private float maxEarthChannelDuration;

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
        earthDuration -= Time.deltaTime;  // Counts down the duration of the cloud

        if (earthDuration <= 0f)  //If the countdown reaches 0 the spell is cancled
        {
            CancleSpell();
        }
    }

    private void OnTriggerEnter(Collider other)         //checks if the Player touches a Field
    {
        if (other.tag == "Field")
        {
            Debug.Log("Earthing Field");
            IsOnField = true;                           //sets the bool for it to true
            CurrentField = other.gameObject;            //references the current field; used for SeedField to know which field is seeded

            if (IsOnField)  //If the cloud is above a field it is watered
            {
                CurrentField.GetComponent<FieldManager>().SetIsPlowed(true);
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
        Destroy(gameObject);
        Camera = GameObject.Find("CameraHolder");
        Camera.GetComponent<ObjectFollower>().enabled = true;
        //cloudCam.SetActive(false);
        //player.GetComponent<ControllerMovement>().enabled = true;
        //mainCam.SetActive(true);
        //countdown = cloudDuration;
    }

    public void SetEarthDuration(float _duration)  //Simple Setter for the cloud duration
    {
        earthDuration = _duration;
    }

    public float GetMaxEarthChannelDuration()  //Simple Getter for the Maximum Cloud Duration
    {
        return maxEarthChannelDuration;
    }
}
