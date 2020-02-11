using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    //private bool IsOnField = false;
    // private bool TouchesBed = false;
    //GameObject CurrentField;
    Item CurrentItem;

    // GameObject CIO;
    Interactable CurrentInteractable;

    [SerializeField]
    private GameObject Cloud;
    private GameObject Player;
    // private GameObject animator;

    private GameObject CloudInstance;

    private bool channelState = false;
    private float cloudDuration;
    private float maxCloudDuration;

    private float interactionRange = 1.2f;
    private Vector3 raycastHigth = new Vector3(0, 0.3f, 0);
    private Interactable focus;
    private Inventory PlayerInventory;

     public GameObject mainCam;
     public GameObject cloudCam;

    PlayerControls controls; // This is where the Controls and actual Input are saved (via Unity Input System)

    private void Awake()
    {
        controls = new PlayerControls();

        // The Controls via the Unity Action Input System are set here

        controls.Gameplay.Wasser.started += ctx => StartChannel();
        controls.Gameplay.Wasser.canceled += ctx => EndChannel();
        controls.Gameplay.Interact.started += ctx => Interact();

        Player = this.gameObject;

        PlayerInventory = Inventory.instance;        //   animator = GameObject.FindGameObjectWithTag("Animator");
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
                CurrentItem = Inventory.instance.GetFirstItem(); ; // WICHTIG: FindObjectOfType<___>(). ÄNDERN SOBALD INVENTORY STEHT!
                CurrentInteractable.Interact();
            }
        }
    }

    private void StartChannel()  // Checks if there is already a cloud active, if not the Max Duration of the used cloud is pulled here for later use and the channel State is set as true to start the charge up/channel
    {
        if (CloudInstance == null)
        {
            WolkenActions myCloud = Cloud.GetComponent<WolkenActions>();
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

            CloudInstance = Instantiate(Cloud);

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
        CloudInstance.transform.position = Player.transform.position;
        cloudCam.transform.position = mainCam.transform.position;

        WolkenActions myCloud = CloudInstance.GetComponent<WolkenActions>();
        myCloud.SetCloudDuration(_duration);

        CloudInstance.SetActive(true);

         cloudCam.SetActive(true);
         Player.GetComponent<PlayerMovement>().enabled = false;
         mainCam.SetActive(false);
    }

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

    public Item GetCurrentItem()
    {
        return CurrentItem;
    }

    public GameObject GetCloudInstance()
    {
        return CloudInstance;
    }

    public GameObject GetMainCam()
    {
        return mainCam;
    }

    public GameObject GetCloudCam()
    {
        return cloudCam;
    }
}
