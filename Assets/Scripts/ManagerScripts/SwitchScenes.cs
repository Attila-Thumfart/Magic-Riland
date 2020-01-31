using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    private GameObject player;
    
    [SerializeField]
    private Vector3 TargetPosition;
    [SerializeField]
    private string TargetScene;

    private GameObject animator;




    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GameObject.FindGameObjectWithTag("Animator");
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(TargetScene);
        player.GetComponent<PlayerMovement>().SetPlayerPosition(TargetPosition);
    }
}
