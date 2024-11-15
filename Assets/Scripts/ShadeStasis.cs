using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class ShadeStasis : MonoBehaviour
{
    public LayerMask groundMask;

    private StasisObject obj;

    // the collider only accepts stasisables
    // can safely call RB's
    private void Awake() {   
    }

    private void OnTriggerStay(Collider other) {
        obj = other.GetComponent<StasisObject>();

        if(obj == null){
            Debug.Log("Nuller" + name + " " +other.name);
            return;
        }

        Vector3 dir = transform.position - other.transform.position;
        // check if obj is in this light's shadow
        if(Physics.Raycast(other.transform.position, dir, dir.magnitude, groundMask)){
            if(obj.litBy == this){
                obj.litBy = null;
            }
            return;
        }

        obj.litBy = this;
    }
}
