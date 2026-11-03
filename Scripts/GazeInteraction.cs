using UnityEngine;

public class GazeInteraction : MonoBehaviour {

    public float gazeTime = 2f;
    private GameObject actualObject;
    private float counter = 0f;

    void Update() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit impact;

        if (Physics.Raycast(ray, out impact, 20f)) {
            GameObject newObject = impact.collider.gameObject;
            if (newObject != actualObject) {
                actualObject = newObject;
                counter = 0f;
            }

            if (newObject.GetComponent<Collectible>() != null ||
                newObject.GetComponent<Magnet>() != null) {
                counter += Time.deltaTime;

                if (counter >= gazeTime) {
                    if (newObject.GetComponent<Collectible>() != null) {
                        newObject.GetComponent<Collectible>().Collect();
                    }
                    if (newObject.GetComponent<Magnet>() != null) {
                        newObject.GetComponent<Magnet>().Activate();
                    }
                    counter = 0f;
                    actualObject = null;
                }
            }
        }
        else {
            actualObject = null;
            counter = 0f;
        }
    }
}