using UnityEngine;

public class Magnet : MonoBehaviour {
    public void Activate() {
        Collectible[] objects = FindObjectsByType<Collectible>();
        foreach (Collectible currentObject in objects) {
            currentObject.Collect();
        }
        Debug.Log("Se recogen todos los objetos");
    }
}
