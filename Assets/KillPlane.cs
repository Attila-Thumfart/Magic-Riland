using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    private GameObject Player;
    private Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        StartPosition = Player.transform.position;

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)                         //if something hits the collider of the game object this script is attached to
    {
        if (other.tag == "Player")                                      //if this is a player
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        Player.transform.position = StartPosition;
    }
}
