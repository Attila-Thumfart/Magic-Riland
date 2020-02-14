using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] private float speed;

    private Transform playerTransform;
    PlayerControls controls;
    private Vector2 axis;

    private void Awake()
    {
        controls = new PlayerControls();
        playerTransform = GameObject.Find("Player").transform;

        controls.Gameplay.Camera.performed += ctx => axis = ctx.ReadValue<Vector2>();
        controls.Gameplay.Camera.canceled += ctx => axis = Vector2.zero;
    }

    void Update()
    {
        Debug.Log(axis.x);

        transform.SetPositionAndRotation(playerTransform.position, transform.rotation);
        transform.Rotate(0f, axis.x * speed, 0f, Space.Self);
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
