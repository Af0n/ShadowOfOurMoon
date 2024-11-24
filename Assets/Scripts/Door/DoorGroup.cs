using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGroup : MonoBehaviour
{
    [Range(1, 5)]
    public int buildingNum;
    public bool isUnlocked;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    isUnlocked = !isUnlocked;
        //    //Debug.Log("is open: " + isUnlocked);
        //}
    }

    public bool TryUnlock()
    {
        bool playerHasCard = KeyCardManager.instance.hasCard(buildingNum);
        isUnlocked = playerHasCard;
        return playerHasCard;
    }

}
