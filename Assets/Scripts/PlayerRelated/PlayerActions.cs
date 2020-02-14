using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    Item CurrentItem;                   //first item in inventory
    Interactable CurrentInteractable;   //the object the player is facing when interacting with something

    [SerializeField]
    private GameObject Player;          //defines the object this script is attached to

    [SerializeField]
    private GameObject Cloud;           //cloud for the player to summon
    private GameObject CloudInstance;   //instance of the cloud (to not work on the prefab)

    private bool channelState = false;  //used for the channel of the cloud
    private float cloudDuration;        //duration of the cloud after being summoned
    [SerializeField]
    private float maxCloudDuration;     //maximum duration of the cloud


    private float interactionRange = 1.2f;                          //range of the player to interact with
    private Vector3 raycastHigth = new Vector3(0, 0.3f, 0);         //GETS CHANGED AFTER REWORKING RAYCAST TO RAYSPHERE


    private Inventory PlayerInventory;      //inventory of the player

    PlayerControls controls;                // This is where the Controls and actual Input are saved (via Unity Input System)

    private void Awake()
    {
        controls = new PlayerControls();        //Unity Input Action System activated here

        // The Controls via the Unity Action Input System are set here
        controls.Gameplay.Wasser.started += ctx => StartChannel();
        controls.Gameplay.Wasser.canceled += ctx => EndChannel();
        controls.Gameplay.Interact.started += ctx => Interact();

        Player = this.gameObject;               //defines the game object of this script as a Player

        PlayerInventory = Inventory.instance;   //creates an instance of the player inventory
    }


    private void FixedUpdate()
    {
        ChannelCounter();
    }

    void Interact()                             //calls the function Interact() of every object the player interacts with
    {
        RaycastHit hit;                         //GETS CHANGED AFTER SWITCHING TO RAYSPHERE
        Ray interactionRay = new Ray(transform.position + raycastHigth, transform.TransformDirection(Vector3.forward) * interactionRange);      //throws a raycast in front of the player

        Debug.DrawRay(transform.position + raycastHigth, transform.TransformDirection(Vector3.forward) * interactionRange);         //visualisation of the raycast for debug purposes

        if (Physics.Raycast(interactionRay, out hit, interactionRange))                 //if raycast/RAYSPHERE hits something
        {
            CurrentInteractable = hit.collider.GetComponent<Interactable>();            //returns the hit interactable gameobject
            if (CurrentInteractable != null)                                            //if there is one interactable
            {
                CurrentItem = Inventory.instance.GetCurrentItem();                      //returns the first item from the inventory
                CurrentInteractable.Interact();                                         //calls interact of the hit object
            }
        }
    }

    private void StartChannel()                                                 //when the player starts to channel the cloud
    { 
        if (CloudInstance == null)                                              //if there is no cloud active
        {
            WolkenActions myCloud = Cloud.GetComponent<WolkenActions>();        //player gets a cloud to use
            maxCloudDuration = myCloud.GetMaxCloudChannelDuration();            //max cloud channel duration is set

            channelState = true;                                                //sets the channel state for the player on true
        }
    }

    private void ChannelCounter()  // the counter that measures the channel duration, if the maximum channel duration is reached it automatically casts the spell fully charged and stops the counter
    {
        if (channelState)                           //while the player starts channeling
        {
            cloudDuration += Time.deltaTime;        //cloud duration gets increased
        }

        if (channelState && cloudDuration >= maxCloudDuration)      //while the player is channeling and the channel duration is less then the maximum cloud duration
        {
            channelState = false;                                   //ends the channeling
            cloudDuration = maxCloudDuration;                       //sets the cloud duration to the max cloud duration (to not get any weird numbers)
            EndChannel();                                           //calls EndChannel()
        }
    }

    private void EndChannel()  //gets called after the player ends his channel
    {
        if (cloudDuration < 1f)         //if the player pressed the button for less than one second
        {
            channelState = false;       //channel gets ended WITHOUT spawning the cloud
            cloudDuration = 0f;         //duration of the cloud gets reset

        }
        else if (cloudDuration >= 1f)                   //if the player pressed the button for more than one second
        {
            channelState = false;                       //channel gets ended

            CloudInstance = Instantiate(Cloud);         //creates an instance of the cloud

            WaterSpell(cloudDuration * 2);              //waterspell gets activated with 2 times the channeltime
            cloudDuration = 0f;                         //duration of the cloud gets reset
        }
    }


    private void WaterSpell(float _duration)   // Spawns a cloud on the player position and sets its duration
    {
        CloudInstance.transform.position = Player.transform.position;           //sets the cloud position to the position of the player (GETS MAYBE CHANGED WITH OTHER CAMERA MOVEMENT)

        WolkenActions myCloud = CloudInstance.GetComponent<WolkenActions>();    //gets an instance of WolkenActions
        myCloud.SetCloudDuration(_duration);                                    //sets the duration of the cloud to the channel duration in EndChannel()

        CloudInstance.SetActive(true);                                          //activates the cloud
    }

    public Item GetCurrentItem()            //returns the first item from the inventory (used in FieldManager)
    {
        return CurrentItem;
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
