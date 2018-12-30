using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player1") || coll.CompareTag("Player2"))
        {
            Destroy(coll.gameObject);
        }
    }
}
