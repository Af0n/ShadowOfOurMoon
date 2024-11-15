using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StasisObject : MonoBehaviour
{
    public ShadeStasis litBy;

    private bool IsNotLit{
        get{ return litBy == null; }
    }

    private Rigidbody rb;

    private void Awake() {
        litBy = null;
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        rb.isKinematic = IsNotLit;
    }
}
