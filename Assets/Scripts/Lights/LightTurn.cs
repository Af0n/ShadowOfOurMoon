using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightTurn : MonoBehaviour
{
    private float deltaAngle;
    private float speed;

    private bool isTurning;

    private float angleTraveled;

    private void Awake() {
        angleTraveled = 0;
    }

    private void Update() {
        if(!isTurning){
            return;
        }

        if(Mathf.Abs(angleTraveled - deltaAngle) > 1){
            float turnNow = speed * Time.deltaTime;
            angleTraveled += turnNow;
            transform.Rotate(Vector3.up, turnNow);
            return;
        }

        isTurning = false;
    }

    public void Turn(float turnAngle, float turnSpeed){
        if(isTurning){
            return;
        }
        angleTraveled = 0;

        deltaAngle = turnAngle;
        speed = turnSpeed;

        isTurning = true;
    }
}
