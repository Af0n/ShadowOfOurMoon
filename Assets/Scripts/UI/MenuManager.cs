using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    PauseMenu pauseMenu;
    SettingsMenu settingsMenu;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("Eos");
            togglePause();  
        }
    }

    private void togglePause()
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
}
