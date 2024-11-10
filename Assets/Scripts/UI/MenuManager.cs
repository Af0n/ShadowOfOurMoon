using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public SettingsMenu settingsMenu;

    public static MenuManager instance;

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
        if (!pauseMenu.gameObject.activeSelf)
        {
            pauseMenu.gameObject.SetActive(true);
        }
        else
        {
            pauseMenu.gameObject.SetActive(false);
        }
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
