using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

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

            controller.multipler = Mathf.Max(health, 0.25f);
            
            return;
        }
        rb.isKinematic = IsNotLit;
    }
}
