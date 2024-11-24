using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float range;
    public bool doingInteract;
    public LayerMask interactMask;
    public Transform cam;
    public float toggleTime;

    private float toggleTimer;

    public void TryInteract(){
        RaycastHit hit;
        Physics.Raycast(cam.position, cam.forward, out hit, range, interactMask);

        if(hit.transform != null){
            hit.transform.GetComponent<Interaction>().DoInteract();
        }
    }
}
