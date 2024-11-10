using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void ToggleStaticFX()
    {
        Debug.Log("FX Toggled");
        PostProcessManager.instance.ToggleGrain();
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    PostProcessManager.instance.ToggleGrain();
        //}
    }

    public void ExitClicked()
    {
        this.gameObject.SetActive(false);
        MenuManager.instance.togglePause();
    }
}
