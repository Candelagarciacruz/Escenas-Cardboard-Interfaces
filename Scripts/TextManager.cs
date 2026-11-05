using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour {
    public static TextManager instance;
    public TextMeshProUGUI textMarker;
    private int recollectedObjects = 0;
    private int totalObjects = 0;

    void Awake() {
        instance = this;
    }

    void Start() {
        totalObjects = FindObjectsByType<Collectible>().Length;
        ActualizeText();
    }

    public void AddObject() {
        recollectedObjects++;
        ActualizeText();
    }

    public void ShowAllCollected() {
        recollectedObjects = totalObjects;
        if (textMarker != null) {
            textMarker.text = "Se han recolectado todos los objetos";
        }
    }

    private void ActualizeText() {
        if (textMarker != null) {
            textMarker.text = "Recolectados: " + recollectedObjects + " / " + totalObjects;
        }
    }
}
