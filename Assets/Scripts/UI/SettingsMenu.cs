using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void ToggleStaticFX()
    {
        Debug.Log("FX Toggled");
    }

    public void ExitClicked()
    {
        this.gameObject.SetActive(false);
    }
}
