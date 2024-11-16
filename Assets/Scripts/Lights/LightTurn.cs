using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightTurn : MonoBehaviour
{
    public void Turn(float speed){
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
