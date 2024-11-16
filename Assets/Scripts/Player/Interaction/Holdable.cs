using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : Interaction
{
    public static Holdable objectHeld; // Assigned only when the player is holding something
    public override void DoInteract()
    {
        if(objectHeld == null)
        {
            StartCoroutine(OnHold());
        }
        else if (objectHeld != null && this != objectHeld)
        {
            //StartCoroutine(objectHeld.OnRelease());
            StartCoroutine(OnHold());
        }
    }

    public void Update()
    {
        if (objectHeld != null && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(OnRelease());
        }
    }

    public IEnumerator OnHold()
    {
        yield return null;
        objectHeld = this;
        Debug.Log("Holding Object");
    }

    public IEnumerator OnRelease()
    {
        yield return null;
        objectHeld = null;
        Debug.Log("Released Object");
    }
}
