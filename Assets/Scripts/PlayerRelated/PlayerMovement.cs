using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5f;  // Playerspeed, editable in the Editor




    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        PlayerTransformation();
    }

    
    void PlayerTransformation()    // Movement for WASD and dependend on playerSpeed
    {
        if (Input.GetKey("w"))
        {
            transform.position = transform.position + new Vector3(0f, 0f, playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            transform.position = transform.position + new Vector3(0f, 0f, -playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            transform.position = transform.position + new Vector3(-playerSpeed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey("d"))
        {
            transform.position = transform.position + new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
        }
    }
    
}
