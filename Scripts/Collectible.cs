using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {
     
    public float speed = 4f;
    private bool collected = false;

    public void Collect()
    {
        if (!collected) {
            collected = true;
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
