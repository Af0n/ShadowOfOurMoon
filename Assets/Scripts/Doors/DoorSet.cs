using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the two parts of one door
public class DoorSet : MonoBehaviour
{
    private DoorGroup doorGroup; // used to check if this door set is unlocked

    public Transform doorLeft;
    public Transform doorRight;

    private float slideDistance = 2f;
    private float speed = 2f;

    private Vector3 leftStartPos;
    private Vector3 rightStartPos;
    public bool isOpening = false;

    void Start()
    {
        leftStartPos = doorLeft.position;
        rightStartPos = doorRight.position;
        doorGroup = GetComponentInParent<DoorGroup>();
    }

    private IEnumerator OpenDoorSet(float duration)
    {
        yield return null;

    }

    void Update()
    {   
        // Trigger door opening (for example, with a key press)
        //if (Input.GetKeyDown(KeyCode.E)) // Replace with your desired trigger
        //{
        //    //isOpening = !isOpening; // Toggle the door state

        //    doorGroup.isUnlocked = doorGroup.isUnlocked == true ? false : true;
        //    Debug.Log("Doors Opened:" +  doorGroup.isUnlocked);
        //}

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

    private void OnTriggerExit(Collider collider)
    {
        PlayerInteract player = collider.gameObject.GetComponent<PlayerInteract>();
        if (player != null && isOpening)
        {
            Debug.Log("Player exited trigger");
            isOpening = false;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        PlayerInteract player = collider.gameObject.GetComponent<PlayerInteract>();

        // If player has the given keycard, let the door be unlocked



        if (player != null)
        {
            Debug.Log("Player entered trigger");
            if (!doorGroup.isUnlocked)
            {
                bool unlocked = doorGroup.TryUnlock();
                // TODO: Set door display based on this result;
                Debug.Log("Door unlocked?: " +  unlocked);
            }

            if (doorGroup.isUnlocked && !isOpening)
            {
                isOpening = true;
            }

            
        }

        
    }

}
