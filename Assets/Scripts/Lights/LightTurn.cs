using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightTurn : MonoBehaviour
{
    public static bool hasFluid;

    
    private void Awake() {
        hasFluid = false;
    }

    public void Turn(float speed){
        if(!hasFluid){
            return;
        }

        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
