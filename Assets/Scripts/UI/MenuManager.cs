using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public SettingsMenu settingsMenu;

    public static MenuManager instance;

    public bool isPaused;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            togglePause();  
        }
    }

    public void togglePause()
    {
        // Checking for any pause menu being active
        if (!isPaused)
        {
            OpenPauseMenu();
            Time.timeScale = 0f;
        }
        else if (pauseMenu.gameObject.activeSelf)
        {
            // Only enters if in the pause menu
            HidePauseMenu();
        }
    }

    public void GameResumed()
    {
        HidePauseMenu();
        Time.timeScale = 1.0f;
    }

    public void HidePauseMenu()
    {
        pauseMenu.gameObject.SetActive(false);
        isPaused = false;
    }

    public void OpenPauseMenu()
    {
        pauseMenu.gameObject.SetActive(true);
        isPaused = true;
    }

    public void onSettingsClicked()
    {
        settingsMenu.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
    }

    public void onExitClicked()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
