using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LampTurnBtn : Interaction
{
    public float turnSpeed;

    public LightTurn lightTurn;

    public override void DoInteract()
    {
        lightTurn.Turn(turnSpeed);
    }
}
