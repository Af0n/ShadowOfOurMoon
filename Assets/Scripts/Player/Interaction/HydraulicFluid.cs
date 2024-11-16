using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraulicFluid : Interaction
{
    public override void DoInteract()
    {
        LightTurn.hasFluid = true;
        Destroy(gameObject);
    }
}
