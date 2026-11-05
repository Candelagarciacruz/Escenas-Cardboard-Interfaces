using UnityEngine;

public class RecoverCollected : MonoBehaviour {
     public void Activate() {
        Collectible[] objects = FindObjectsByType<Collectible>();
        foreach (Collectible collectedObject in objects) {
            collectedObject.Magnetize();
        }

        if (TextManager.instance != null) {
            TextManager.instance.ShowAllCollected();
        }
    }
}
