using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider brightnessSlider;
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

    public void OnBrightnessChanged()
    {
        float brightness = (brightnessSlider.value - 0.8f) * 2;
        PostProcessManager.instance.SetBrightness(brightness);
    }
}
