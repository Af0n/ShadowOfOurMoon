using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider brightnessSlider;

    public void EnableGrain()
    {
        PostProcessManager.instance.EnableGrain();
    }

    public void DisableGrain()
    {
        PostProcessManager.instance.DisableGrain();
    }

    public void ExitClicked()
    {
        this.gameObject.SetActive(false);
        MenuManager.instance.OpenPauseMenu();
    }


    public void ResetClicked()
    {
        volumeSlider.value = 1f;

        brightnessSlider.value = 0.8f;
        OnBrightnessChanged();

        EnableGrain();

    }

    public void OnVolumeChanged()
    {
        float volume = volumeSlider.value;
        // TODO: Access a volume manager and set the audio there
    }

    public void OnBrightnessChanged()
    {
        SetBrightness(brightnessSlider.value);
    }

    public void SetBrightness(float sliderValue)
    {
        float brightness = (sliderValue - 0.8f) * 2;
        PostProcessManager.instance.SetBrightness(brightness);
    }
}
