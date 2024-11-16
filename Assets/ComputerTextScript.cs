using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ComputerTextScript : Interaction
{
    public LoreLog lore;
    public LoreCanvas canvas;
    private void Start() {
        GameObject getCanvas = GameObject
                .FindGameObjectWithTag("LoreCanvas");
        if(getCanvas == null) {
            Debug.LogError("No canvas in scene");
        }
        canvas = getCanvas.GetComponent<LoreCanvas>();
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (!other.CompareTag("Player")) return;
    //     if (lore == null) return;
    //     canvas.Toggle();
    //     canvas.loreText.text = lore.log;
    // }
    // private void OnTriggerExit(Collider other)
    // {
    //     // Hide the canvas when the player exits the trigger zone
    //     if (!other.CompareTag("Player")) return;
    //     if (canvas == null) return;
    //     canvas.Toggle();
    //     canvas.loreText.text = "";
    // }

    public override void DoInteract()
    {
        if (lore == null) return;
        canvas.Toggle();
        canvas.loreText.text = lore.log;
    }
}
