using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGroup : MonoBehaviour
{
    // Close both Door Sets when the player exits the trigger
    DoorSet innerDoors;
    DoorSet outerDoors;
    private void OnTriggerExit(Collider collider)
    {
        //
        innerDoors.isOpening = false;
        outerDoors.isOpening = false;
    }
}
