using TMPro;
using UnityEngine;

public class LoreCanvas : MonoBehaviour
{
    public TextMeshProUGUI loreText; 
    public void Toggle() {
        loreText.gameObject.SetActive(!loreText.gameObject.activeSelf);
    }
}
