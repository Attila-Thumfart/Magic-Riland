using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WolkenMovement : MonoBehaviour
{
    [SerializeField]
    private float cloudSpeed = 5f;  // Playerspeed, editable in the Editor

    PlayerControls controls; // This is where the Controls and actual Input are saved (via Unity Input System)
    private Vector2 move;            // Vector to save the JoyStick Inputs X and Y

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.MoveSpell.performed += ctx => move = ctx.ReadValue<Vector2>();  // When the action defined in controls is performed read and save the values of the Joystick in a Vector2
        controls.Gameplay.MoveSpell.canceled += ctx => move = Vector2.zero;               // When there is no input the vector is 0
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x * cloudSpeed, 0f, move.y * cloudSpeed) * Time.deltaTime; // X and Y Values of the JoyStick are multiplyed with the Playerspeed
        transform.Translate(movement, Space.World); // The values are applied to move the player in relation to the world
    }

    private void OnEnable() // This function enables the controls when the object becomes enabled and active
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable() // This function disables the csontrols when the object becomes disabled or inactive
    {
        controls.Gameplay.Disable();
    }
}
