using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeStasis : MonoBehaviour
{
    private bool canStasis;
    // the collider only accepts stasisables
    // can safely call RB's
    private void OnTriggerEnter(Collider other) {
        other.GetComponent<Rigidbody>().isKinematic = false;
        StartCoroutine("StasisDelay");
    }

    private IEnumerator StasisDelay(){
        canStasis = false;
        yield return new WaitForSeconds(0.1f);
        canStasis = true;
    }

    private void OnTriggerExit(Collider other) {
        if(!canStasis){
            return;
        }
        other.GetComponent<Rigidbody>().isKinematic = true;
    }
}
