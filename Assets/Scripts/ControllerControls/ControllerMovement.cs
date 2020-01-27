using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5f;  // Playerspeed, editable in the Editor
    
    private PlayerControls controls;
    private Vector2 move;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x * playerSpeed, 0f, move.y * playerSpeed) * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
