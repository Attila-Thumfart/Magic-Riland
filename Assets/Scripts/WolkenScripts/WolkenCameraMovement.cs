using UnityEngine;

public class WolkenCameraMovement : MonoBehaviour
{
    private GameObject wolke;              //Player an dem die Camera hängt
    private Transform target;               //Position, Rotation und Scale vom Target (Player)

    [SerializeField]
    private float smoothSpeed = 0.125f;     //Speed for Cameradelay when moving the Player

    [SerializeField]
    private Vector3 offset;                 //Used for Positioning the Camera in relation to the Player


    private void Awake()
    {
        wolke = GameObject.Find("TestWolke");   //Finding the Player in the scene
        target = wolke.transform;            //Setting target in dependend on the Player
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
    }
}
