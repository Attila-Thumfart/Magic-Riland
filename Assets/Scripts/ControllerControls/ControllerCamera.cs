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

    PlayerControls controls; // This is where the Controls and actual Input are saved (via Unity Input System)

    private Vector3 facingNorth = new Vector3(0, 4, -7);
    private Vector3 facingEast = new Vector3(7, 4, 0);
    private Vector3 facingSouth = new Vector3(0, 4, 7);
    private Vector3 facingWest = new Vector3(-7, 4, 0);

    private enum cameraAngle { facingNorth, facingEast, facingSouth, facingWest };

    private void Awake()
    {
        player = GameObject.Find("Player");   //Finding the Player in the scene
        target = player.transform;            //Setting target in dependend on the Player

        offset = facingNorth;

        controls = new PlayerControls();

        controls.Gameplay.CameraRight.started += ctx => TurnRight();
        controls.Gameplay.CameraLeft.started += ctx => TurnLeft();
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
    
        if(Input.GetKey(KeyCode.T))
        {
            TurnLeft();
        }
    }

  /*  void AdjustCamera ()
    {
        
        switch (angle)
        {
            case cameraAngle.facingNorth:
                offset = new Vector3(0, 4, -7);
                break;

            case cameraAngle.facingEast:
                offset = new Vector3(7, 4, 0);
                break;

            case cameraAngle.facingSouth:
                offset = new Vector3(0, 4, 7);
                break;

            case cameraAngle.facingWest:
                offset = new Vector3(-7, 4, 0);
                break;
        }
    }*/

    private void TurnRight()
    {
        if(offset == facingNorth)
        {
            offset = facingEast;
        }
    }

    private void TurnLeft()
    {
        offset = new Vector3(offset.x - 7, offset.y, offset.z + 7);       
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