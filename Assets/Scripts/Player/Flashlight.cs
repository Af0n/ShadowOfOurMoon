using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public float maxTime;
    public float rechargeRate;
    public float burnoutTime;
    public float toggleTime;
    [Header("Unity Set Up")]
    public Light flashy;

    private float batteryTimer;
    private float burnoutTimer;
    private float toggleTimer;

    // 0: off
    // 1: on
    // -1: burned
    private int state;

    public bool IsOn{
        get { return state == 1; }
    }

    public bool IsBurned{
        get { return state == -1; }
    }

    public float PercentCharged
    {
        get { return batteryTimer / maxTime; }
    }

    public float PercentBurned
    {
        get { return burnoutTimer / burnoutTime; }
    }

    private void Awake() {
        state = 0;
        batteryTimer = maxTime;
        burnoutTimer = 0;
    }

    private void Update()
    {
        EvaluateState();
        toggleTimer -= Time.deltaTime;
    }

    public void TryToggle(){
        // don't do anything while counting down toggle
        if(toggleTimer > 0){
            return;
        }

        // don't turn on while burned
        if(IsBurned){
            return;
        }

        if(IsOn){
            state = 0;
        }else{
            state = 1;
        }

        toggleTimer = toggleTime;
    }

    private void EvaluateState()
    {
        switch (state)
        {
            case -1:
                flashy.enabled = false;
                burnoutTimer -= Time.deltaTime;
                if (burnoutTimer <= 0)
                {
                    state = 0;
                }
                break;
            case 0:
                flashy.enabled = false;
                batteryTimer += rechargeRate * Time.deltaTime;
                batteryTimer = Mathf.Clamp(batteryTimer, 0, maxTime);
                break;
            case 1:
                flashy.enabled = true;
                batteryTimer -= Time.deltaTime;
                if (batteryTimer <= 0)
                {
                    burnoutTimer = burnoutTime;
                    state = -1;
                }
                break;
        }
    }
}
