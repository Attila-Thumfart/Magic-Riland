using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    private bool IsOnField = false;
    private bool TouchesBed = false;
    GameObject CurrentField;
    GameObject CurrentItem;

    GameObject CIO;
    Interactable CurrentInteractable;


    [SerializeField]
    private GameObject cloud;
    private GameObject Player;
   // private GameObject animator;

    private bool channelState = false;
    private float cloudDuration;
    private float maxCloudDuration;

    private float interactionRange = 1.2f;
    private Vector3 raycastHigth = new Vector3(0, 0.3f, 0);
    private Interactable focus;

    // public GameObject mainCam;
    // public GameObject cloudCam;

    PlayerControls controls; // This is where the Controls and actual Input are saved (via Unity Input System)

    private void Awake()
    {
        controls = new PlayerControls();

        // The Controls via the Unity Action Input System are set here

        controls.Gameplay.Wasser.started += ctx => StartChannel();
        controls.Gameplay.Wasser.canceled += ctx => EndChannel();
        controls.Gameplay.Interact.performed += ctx => Interact();
        // controls.Gameplay.Interact.performed += ctx => FieldAction();
        // controls.Keyboard.Interact.performed += ctx => FieldAction();
        // controls.Gameplay.Interact.performed += ctx => EndDay();
        // controls.Keyboard.Interact.performed += ctx => EndDay();

        Player = this.gameObject;
     //   animator = GameObject.FindGameObjectWithTag("Animator");
    }


    private void FixedUpdate()
    {
        ChannelCounter();
    }

    void Interact()
    {
            RaycastHit hit;
            Ray interactionRay = new Ray(transform.position + raycastHigth, transform.TransformDirection(Vector3.forward) * interactionRange);

            Debug.DrawRay(transform.position + raycastHigth, transform.TransformDirection(Vector3.forward) * interactionRange);

            if (Physics.Raycast(interactionRay, out hit, interactionRange))
            {
                CurrentInteractable = hit.collider.GetComponent<Interactable>();
                if (CurrentInteractable != null)
                {
                    CurrentItem = GameObject.FindObjectOfType<MySamplePlant>().gameObject;
                    CurrentInteractable.Interact();
                }
            }
    }

    private void StartChannel()  // Checks if there is already a cloud active, if not the Max Duration of the used cloud is pulled here for later use and the channel State is set as true to start the charge up/channel
    {

        if (cloud.activeSelf == false)
        {
            WolkenActions myCloud = cloud.GetComponent<WolkenActions>();
            maxCloudDuration = myCloud.GetMaxCloudChannelDuration();

            channelState = true;
        }
    }

    private void EndChannel()  // Activates when the button is released and stops the counter, if it is above the threshold a cloud is spawned with a duration according to the channel time
    {
        if (cloudDuration < 1f)
        {
            channelState = false;
            cloudDuration = 0f;
        }
        else if (cloudDuration >= 1f)
        {
            channelState = false;
            WaterSpell(cloudDuration * 2);
            cloudDuration = 0f;
        }
    }

    private void ChannelCounter()  // the counter that measures the channel duration, if the maximum channel duration is reached it automatically casts the spell fully charged and stops the counter
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

    private void WaterSpell(float _duration)   // Spawns a cloud on the player position and sets its duration
    {
        cloud.transform.position = Player.transform.position;
        //cloudCam.transform.position = mainCam.transform.position;

        WolkenActions myCloud = cloud.GetComponent<WolkenActions>();
        myCloud.SetCloudDuration(_duration);

        cloud.SetActive(true);

        // cloudCam.SetActive(true);
        // player.GetComponent<ControllerMovement>().enabled = false;
        // mainCam.SetActive(false);
    }
/*
    private void OnTriggerEnter(Collider other)         //checks if the Player touches a Field
    {

        if (other.tag == "Field")
        {
            IsOnField = true;                           //sets the bool for it to true
            CurrentField = other.gameObject;            //references the current field; used for SeedField to know which field is seeded
        }

        else if (other.name == "Bed")
        {
            TouchesBed = true;
        }
    }

    private void OnTriggerExit(Collider other)          //checks if the Player stops touching a field
    {
        if (other.tag == "Field")
        {
            IsOnField = false;                          //sets the bool for it to false
            CurrentField = null;                        //dereferences the current field 
        }

        else if (other.name == "Bed")
        {
            TouchesBed = false;
        }
    }

    void SeedField()                                    //Seeds the field and gives over the plants information
    {
        /*
        CurrentField.GetComponent<FieldManager>().SetIsSeeded(true);
        CurrentField.GetComponent<FieldManager>().SetGrowthrates(CurrentItem);
        CurrentField.GetComponent<FieldManager>().SetMeshes(CurrentItem);
        CurrentField.GetComponent<FieldManager>().SetItem(CurrentItem);
    }

    void HarvestField()                                 //Harvests the field the player is standing on
    {
        CurrentField.GetComponent<FieldManager>().ResetField();
        Inventory.instance.Add(CurrentField.GetComponent<FieldManager>().GetItem());
    }

    public void FieldAction()
    {
        if (IsOnField)
        {
            if (CurrentField.GetComponent<FieldManager>().GetFieldstate() == FieldManager.Fieldstate.empty)         //if the field the player is standing on is empty
            {
                //and if there is a Plant in the scene (Later: if the first item in inventory is a seed)
                SeedField();                                                                                        //seeds the field
            }

            if (CurrentField.GetComponent<FieldManager>().GetFieldstate() == FieldManager.Fieldstate.finished)      //if the field the player is standing on has a grown up plant
            {
                HarvestField();                                                                                     //harvests the field
            }

            if (CurrentField.GetComponent<FieldManager>().GetFieldstate() == FieldManager.Fieldstate.withered)
            {
                HarvestField();
            }
        }
    }
*/
   /* void EndDay()
    {
        if (TouchesBed)           //if the player touches the Bed and presses "E"
        {
            TouchesBed = false;
            GameManager.GMInstance.IncrementCalenderDay();      //end the day 
            GetComponent<PlayerMovement>().enabled = false;
            animator.GetComponent<FadingManager>().SetFade(true);
        }
    }*/

    public Interactable GetFocus()
    {
        return focus;
    }

    public void EnableMovement()
    {
        GetComponent<PlayerMovement>().enabled = true;
    }

    private void OnEnable() // This function enables the controls when the object becomes enabled and active
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable() // This function disables the controls when the object becomes disabled or inactive
    {
        controls.Gameplay.Disable();
    }

    public GameObject GetCurrentItem()
    {
        return CurrentItem;
    }
}
