using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class ShadeStasis : MonoBehaviour
{
    public LayerMask groundMask;
    public Transform lightPos;
    public Flashlight flashy;

    private StasisObject obj;

    // the collider only accepts stasisables
    // can safely call RB's
    private void Awake()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        obj = other.GetComponent<StasisObject>();

        if (flashy != null)
        {
            if (!flashy.IsOn)
            {
                if (obj.litBy == this)
                {
                    obj.litBy = null;
                }
                return;
            }
        }

        Vector3 dir = lightPos.position - other.transform.position;

        // check if obj is in this light's shadow
        if (Physics.Raycast(other.transform.position, dir, dir.magnitude, groundMask))
        {
            if (obj.litBy == this)
            {
                obj.litBy = null;
            }
            return;
        }

        // don't light self
        if(obj.CompareTag(tag)){
            return;
        }

        obj.litBy = this;
    }

    private void OnTriggerExit(Collider other) {
        obj = other.GetComponent<StasisObject>();

        if(obj.litBy == this){
            obj.litBy = null;
        }
    }
}
