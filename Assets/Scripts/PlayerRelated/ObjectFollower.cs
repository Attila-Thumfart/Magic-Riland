using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform upDownHolder;


    private Transform playerTransform;

    private Vector3 playerDirection;
    PlayerControls controls;
    private Vector2 axis;
    private float CountUntilReset;

    private void Awake()
    {
        controls = new PlayerControls();
        playerTransform = GameObject.Find("Player").transform;

        controls.Gameplay.Camera.performed += ctx => axis = ctx.ReadValue<Vector2>();
        controls.Gameplay.Camera.canceled += ctx => axis = Vector2.zero;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SetCameraBehindPlayer();
        }
        // Debug.Log(axis.x);
        // Debug.Log(axis.y);
        Debug.Log("The camera direction is " + transform.rotation);

        transform.SetPositionAndRotation(playerTransform.position, transform.rotation);

       // CountUntilReset += Time.deltaTime;

        if (axis.x > 0.1f || axis.x < -0.1f)
        {
            //transform.Rotate(0f, axis.x * speed, 0f, Space.Self);
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + axis.x * speed, transform.rotation.eulerAngles.z));
        }

        if (axis.y > 0.1f || axis.y < -0.1f)
        {
            float Angle = upDownHolder.rotation.eulerAngles.x + axis.y * speed;

            if(Angle < 45 && Angle > 5)
            {
                upDownHolder.SetPositionAndRotation(upDownHolder.position, Quaternion.Euler(Angle, upDownHolder.rotation.eulerAngles.y, upDownHolder.rotation.eulerAngles.z));
            }
           
            Debug.Log("The Angle is " + Angle);
            //transform.Rotate(axis.y * speed, 0f, 0f, Space.Self);
        }

       /* if (CountUntilReset > 1)
        {
            SetCameraBehindPlayer();
            Debug.Log("Camera Reset");
            CountUntilReset = 0;
        }*/
    }

    public void SetCameraBehindPlayer()
    {
        playerDirection = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().GetPlayerDirection();
        transform.SetPositionAndRotation(playerTransform.position, Quaternion.LookRotation(playerDirection, Vector3.up));
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
