using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5f;  // Playerspeed, editable in the Editor

    [SerializeField]
    CharacterController characterController;

    PlayerControls controls; // This is where the Controls and actual Input are saved (via Unity Input System)
    private Vector2 move;            // Vector to save the JoyStick Inputs X and Y
   
    [SerializeField]
    private float Gravity = 4f;

    [SerializeField] private Transform cameraHolder;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();  // When the action defined in controls is performed read and save the values of the Joystick in a Vector2
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;               // When there is no input the vector is 0

        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y); // X and Y Values of the JoyStick are multiplyed with the Playerspeed
        movement *= playerSpeed;

        if (move.x == 0 && move.y == 0)
            return;

        float angle = (Vector2.SignedAngle(Vector2.up, new Vector2(move.x, move.y))) * Mathf.PI / 180;

        Vector3 direction = new Vector3(Mathf.Cos(angle) * cameraHolder.forward.x - Mathf.Sin(angle) * cameraHolder.forward.z,
            0f, Mathf.Sin(angle) * cameraHolder.forward.x + Mathf.Cos(angle) * cameraHolder.forward.z);

        transform.SetPositionAndRotation(transform.position + direction * Time.fixedDeltaTime * playerSpeed, Quaternion.LookRotation(direction));
    }

    private void OnEnable() // This function enables the controls when the object becomes enabled and active
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable() // This function disables the controls when the object becomes disabled or inactive
    {
        controls.Gameplay.Disable();
    }

    public void SetPlayerPosition(Vector3 _targetPosition)
    {
        transform.position = new Vector3(_targetPosition.x, _targetPosition.y, _targetPosition.z);
    }
}