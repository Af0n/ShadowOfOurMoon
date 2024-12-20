using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class StasisObject : MonoBehaviour
{
    public float health;
    public float drain;
    public ShadeStasis litBy;

    public PlayerController controller;

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
            }else{
                health += drain * Time.deltaTime;
            }

            health = Mathf.Clamp(health, 0, 1f);
            
            controller.multiplier = Mathf.Max(health, 0.25f);

            return;
        }
        rb.isKinematic = IsNotLit;
    }
}
