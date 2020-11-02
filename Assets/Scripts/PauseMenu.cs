using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenu;

    public Text timeCounter;

    private string timeLabel = "Time: ";

    private float elapsedTime = 0f;

    public GameObject victoryObj;
    
    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "Time: 00:00:00";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC pressed");
            if (gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

        if (!gameIsPaused && !victoryObj.activeSelf)
        {
            UpdateTimer();
        }

        if (victoryObj.activeSelf)
        {
            PlayerPrefs.SetFloat("Player Score New", elapsedTime);
        }

    }
    public void Resume()
    {
        Debug.Log("Resume");
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void GoToMenu()
    {
        Debug.Log("Go to Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void UpdateTimer()
    {
        elapsedTime += Time.deltaTime;

        timeCounter.text = timeLabel + TimeSpan.FromSeconds(elapsedTime).ToString("mm':'ss':'ff");

    }
}
