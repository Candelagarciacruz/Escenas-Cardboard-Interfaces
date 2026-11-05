using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {
     
    private bool collected = false;
    private bool isFlying = false;
    private float speed = 5f;

    // Occurs when the player looks to the recolectable objects.
    public void Collect() {
        if (!collected && !isFlying) {
            collected = true;

            if (GetComponent<Renderer>() != null) {
                GetComponent<Renderer>().enabled = false;
            }
            if (GetComponent<Collider>() != null) {
                GetComponent<Collider>().enabled = false;
            }

            if (TextManager.instance != null) {
                TextManager.instance.AddObject();
            }
        }
    }

    // Occurs when the player looks to the object that recovers the recolectable objects.
    public void Magnetize() {
        if (!collected && !isFlying) {
            isFlying = true;

            if (GetComponent<Collider>() != null) {
                GetComponent<Collider>().enabled = false;
            }
            StartCoroutine(GoToPlayer());
        }
    }

    IEnumerator GoToPlayer() {
        Transform currentPlayer = Camera.main.transform;

        while (Vector3.Distance(transform.position, currentPlayer.position) > 0.3f) {
            transform.position = Vector3.MoveTowards(
                transform.position,
                currentPlayer.position,
                speed * Time.deltaTime
            );
            yield return null;
        }

        Destroy(gameObject);
    }
}
