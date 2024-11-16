using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lore Log", menuName = "Lore Log")]
public class LoreLog : ScriptableObject
{
    [Header("Lore Log Variables")]
    [Tooltip("ID's should be unique")]
    public int id;
    [TextArea(15,20)]
    public string log;
}
