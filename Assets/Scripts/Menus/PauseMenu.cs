using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseMenu : MonoBehaviour
{
    //public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    public GameObject OptionsMenuUI;

    GameObject Player;

    PlayerControls controls; // This is where the Controls and actual Input are saved (via Unity Input System)


    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Menu.started += ctx => Pause();
    }

    //to prevent the game from starting paused
    private void Start()
    {
        PauseMenuUI.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    //Activates UI Elements and stops Game Time
    public void Pause()
    {
        if (!OptionsMenuUI.activeSelf)
        {
            PauseMenuUI.SetActive(!PauseMenuUI.activeSelf);

            if (!PauseMenuUI.activeSelf)
            {
                Time.timeScale = 1f;
                Player.GetComponent<PlayerActions>().enabled = true;
                Player.GetComponent<PlayerMovement>().enabled = true;
            }
            else
            {
                Time.timeScale = 0f;

                StartCoroutine(Coroutine(0.2f, () =>
                {
                    Player.GetComponent<PlayerActions>().enabled = false;
                    Player.GetComponent<PlayerMovement>().enabled = false;
                }));
            }
        }
    }

    // Loads the first scene in the Build order (usually the Main Menu)
    public void LoadMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
    private IEnumerator Coroutine(float _TimeToWait, Action _callback)
    {
        yield return new WaitForSecondsRealtime(_TimeToWait);
        _callback?.Invoke();
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
