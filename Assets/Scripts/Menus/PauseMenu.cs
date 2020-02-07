using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    public GameObject OptionsMenuUI;

    GameObject Player;

    //to prevent the game from starting paused
    private void Start()
    {
        PauseMenuUI.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    //checkes if the pause button is pressed during the runtime
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & !OptionsMenuUI.activeSelf)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    //Deactivates the UI Elements and activates Game Time again
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        StartCoroutine(Coroutine(0.2f, () =>
        {
            Player.GetComponent<PlayerActions>().enabled = true;
            Player.GetComponent<PlayerMovement>().enabled = true;
            GameIsPaused = false;
        }));
    }

    //Activates UI Elements and stops Game Time
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Player.GetComponent<PlayerActions>().enabled = false;
        Player.GetComponent<PlayerMovement>().enabled = false;
        GameIsPaused = true;
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
}
