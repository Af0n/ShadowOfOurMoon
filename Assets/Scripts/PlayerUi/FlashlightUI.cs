using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightUI : MonoBehaviour
{
    [Header("Unity Set Up")]
    public Image flashyBar;
    public Image healthBar;
    public Image burn;
    public Image flare;
    public Flashlight flashScript;
    public FlareThrow flareScript;
    public StasisObject stasis;

    private void Update() {
        flashyBar.fillAmount = flashScript.PercentCharged;
        burn.fillAmount = flashScript.PercentBurned;
        flare.fillAmount = flareScript.PercentCharged;
        healthBar.fillAmount = stasis.health;
    }
}
