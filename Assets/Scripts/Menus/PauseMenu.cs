﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    public GameObject OptionsMenuUI;

    //to prevent the game from starting paused
    private void Start()
    {
        PauseMenuUI.SetActive(false);
    }

    //checkes if the pause button is pressed during the runtime
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) &! OptionsMenuUI.activeSelf)
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

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}