using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SwitchScenes : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private Vector3 TargetPosition;
    [SerializeField]
    private string TargetScene;

    private GameObject animator;

    private IEnumerator Coroutine(int _TimeToWait, Action _callback)
    {
        yield return new WaitForSecondsRealtime(_TimeToWait);
        _callback?.Invoke();

    }


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // animator = GameObject.FindGameObjectWithTag("Animator");
        animator = GameObject.Find("FadeManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            animator.GetComponent<FadingManager>().SetFade(true);
            StartCoroutine(Coroutine(1, () =>
            {
                SceneManager.LoadScene(TargetScene);
                player.GetComponent<PlayerMovement>().SetPlayerPosition(TargetPosition);
                animator.GetComponent<FadingManager>().SetFade(false);
                player.GetComponent<PlayerMovement>().enabled = true;
            }));

        }
    }
}
