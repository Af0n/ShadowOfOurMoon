using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class StasisObject : MonoBehaviour
{
    public float health;
    public float drain;
    public ShadeStasis litBy;

    private bool IsNotLit{
        get{ return litBy == null; }
    }

    private Rigidbody rb;

    private void Awake() {
        health = 1;
        litBy = null;
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if(transform.CompareTag("Player")){
            // do this if the player
            if(IsNotLit){
                health -= drain * Time.deltaTime;
            }
            
            return;
        }
        rb.isKinematic = IsNotLit;
    }
}
