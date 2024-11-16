using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the two parts of one door
public class DoorSet : MonoBehaviour
{
    public Transform doorLeft;
    public Transform doorRight;

    private float slideDistance = 2f;
    private float speed = 2f;

    private Vector3 leftStartPos;
    private Vector3 rightStartPos;
    private bool isOpening = false;

    void Start()
    {
        leftStartPos = doorLeft.position;
        rightStartPos = doorRight.position;
    }

    private IEnumerator OpenDoorSet(float duration)
    {
        yield return null;

    }

    void Update()
    {
        // Trigger door opening (for example, with a key press)
        if (Input.GetKeyDown(KeyCode.E)) // Replace with your desired trigger
        {
            isOpening = !isOpening; // Toggle the door state
        }

        // Move doors based on the state
        if (isOpening)
        {
            doorLeft.position = Vector3.Slerp(doorLeft.position, leftStartPos - new Vector3(0, 0, -slideDistance), Time.deltaTime * speed);
            doorRight.position = Vector3.Slerp(doorRight.position, rightStartPos + new Vector3(0, 0, -slideDistance), Time.deltaTime * speed);
        }
        else
        {
            // Move doors back to their starting positions when closing
            doorLeft.position = Vector3.Slerp(doorLeft.position, leftStartPos, Time.deltaTime * speed);
            doorRight.position = Vector3.Slerp(doorRight.position, rightStartPos, Time.deltaTime * speed);
        }
    }


}
