using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : Interaction
{
    //public static Holdable objectHeld; // Assigned only when the player is holding something
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void DoInteract()
    {
        if(ObjectHolder.instance.heldObject == null)
        {
            StartCoroutine(OnHold());
        }
        else if (ObjectHolder.instance.heldObject != null && this.gameObject != ObjectHolder.instance.heldObject)
        {
            StartCoroutine(OnHold());
        }
    }

    public void Update()
    {
        if (ObjectHolder.instance.heldObject != null)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(OnRelease());
            }
            
        }
    }

    public IEnumerator OnHold()
    {
        yield return null;
        rb.useGravity = false;
        rb.freezeRotation = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        ObjectHolder.instance.heldObject = this.gameObject;
        //Debug.Log("Holding Object");
    }

    public IEnumerator OnRelease()
    {
        yield return null;
        ObjectHolder.instance.heldObject = null;
        rb.useGravity = true;
        rb.freezeRotation = false;
        //Debug.Log("Released Object");
    }
}
