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
    private Vector2 rotate;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();  // When the action defined in controls is performed read and save the values of the Joystick in a Vector2
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;               // When there is no input the vector is 0

        controls.Gameplay.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();  // When the action defined in controls is performed read and save the values of the Joystick in a Vector2

        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y); // X and Y Values of the JoyStick are multiplyed with the Playerspeed
        movement *= playerSpeed;
        characterController.Move(movement * Time.deltaTime);
        //transform.Translate(movement, Space.World); // The values are applied to move the player in relation to the world

        Vector3 rotation = new Vector3(rotate.x, 0f, rotate.y) * Time.deltaTime;
        if(rotation != Vector3.zero)
        transform.rotation = Quaternion.LookRotation(rotation);
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