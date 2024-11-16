using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : Interaction
{
    public CardUnlock cardUnlock;
    public override void DoInteract()
    {
        Debug.Log("Keycard interaction");
        KeyCardManager.instance.AddCard((int)cardUnlock);
    }
}

public enum CardUnlock
{
    buildingThree = 3,
    buildingFour = 4,
    exit = 5
}