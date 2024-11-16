using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public static ObjectHolder instance;

    public Transform holdPoint;
    public GameObject heldObject;
    public float moveSpeed = 10f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if(heldObject != null)
        {
            MoveHeldObject();
        }
    }

    public void MoveHeldObject()
    {
        Rigidbody objRb = heldObject.GetComponent<Rigidbody>();
        Vector3 targetPosition = holdPoint.position;
        Vector3 direction = (targetPosition - heldObject.transform.position) * moveSpeed;
        objRb.velocity = direction;
    }

}
