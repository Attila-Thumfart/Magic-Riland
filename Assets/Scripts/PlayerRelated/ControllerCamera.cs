using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerCamera : MonoBehaviour
{
    private GameObject player;              //Player an dem die Camera hängt
    private Transform target;               //Position, Rotation und Scale vom Target (Player)

    [SerializeField]
    private float smoothSpeed = 0.125f;     //Speed for Cameradelay when moving the Player

    [SerializeField]
    private Vector3 offset;                 //Used for Positioning the Camera in relation to the Player

    PlayerControls controls;                //This is where the Controls and actual Input are saved (via Unity Input System)


    //Hardcoded Offsets for the camera to turn in 90° Steps
    private Vector3 facingNorth = new Vector3(0, 4, -7);
    private Vector3 facingEast = new Vector3(7, 4, 0);
    private Vector3 facingSouth = new Vector3(0, 4, 7);
    private Vector3 facingWest = new Vector3(-7, 4, 0);

    private int resetTimer = 0; //A timer to reset the camera after a certain amount of time

    private void Awake()
    {
        player = GameObject.Find("Player");   //Finding the Player in the scene
        target = player.transform;            //Setting target in dependend on the Player

        offset = facingNorth;                 //The standard offset of the camera is set here

        controls = new PlayerControls();      //Unity Input Action System activated here

        //controls.Gameplay.CameraRight.started += ctx => TurnRight();   //The controls for the camera through the Unity Input Action System
        controls.Gameplay.CameraLeft.started += ctx => TurnLeft();      //The controls for the camera through the Unity Input Action System
    }


    private void Start()
    {
        transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);     //sets the Camera behind the player when starting
    }



    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;                                             //Setting the position the camera will end up at
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);      //Smothing out the Cameramovement
        transform.position = smoothedPosition;                                                          //Moving the Camera when the player is moving

        transform.LookAt(target);                                                                       //Always look towards the player
        resetCamera();                                                                                  //resets the camera to the default position
    }


    // Changes the offset to one of the predefiened ones based on the current offset and activates the reset timer
    private void TurnRight()
    {
        resetTimer = 1;

        if (offset == facingNorth)
        {
            offset = facingEast;
        }
        else if (offset == facingEast)
        {
            offset = facingSouth;
        }
        else if (offset == facingSouth)
        {
            offset = facingWest;
        }
        else if (offset == facingWest)
        {
            offset = facingNorth;
        }
    }

    // Changes the offset to one of the predefiened ones based on the current offset and activates the reset timer
    private void TurnLeft()
    {
        resetTimer = 1;

        if (offset == facingNorth)
        {
            offset = facingWest;
        }
        else if (offset == facingWest)
        {
            offset = facingSouth;
        }
        else if (offset == facingSouth)
        {
            offset = facingEast;
        }
        else if (offset == facingEast)
        {
            offset = facingNorth;
        }
    }

    //Resets the camera after a certain amount of time
    private void resetCamera()
    {
        if(resetTimer >= 1)
        {
            resetTimer++;
        }
        if (resetTimer >= 150)
        {
            resetTimer = 0;

            offset = facingNorth;
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