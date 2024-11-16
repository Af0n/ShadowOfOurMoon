using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PointJustLight : MonoBehaviour
{
    public float radius;
    public Color color;

    private Light liht;
    private SphereCollider col;

    private void Awake() {
        liht = GetComponent<Light>();
        col = GetComponent<SphereCollider>();

        liht.range = radius;
        liht.color = color;
        
        col.radius = radius;
    }
}
