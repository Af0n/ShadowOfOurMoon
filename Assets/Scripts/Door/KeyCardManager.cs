using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardManager : MonoBehaviour
{
    public static KeyCardManager instance;

    private Dictionary<int, bool> keyCardsFound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            keyCardsFound = new Dictionary<int, bool>();
            keyCardsFound.Add(3, false); // to room 3
            keyCardsFound.Add(4, false); // to room 4
            keyCardsFound.Add(5, false); // keycard for exit
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddCard(int unlocksBuildingNo) // call when player collects a keycard
    {
        keyCardsFound[unlocksBuildingNo] = true;
        Debug.Log("Unlocked card: " + unlocksBuildingNo);
    }

    public bool hasCard(int num)
    {
        if (keyCardsFound.ContainsKey(num))
        {
            return keyCardsFound[num];
        }
        else
        {
            return false;
        }
    }
}