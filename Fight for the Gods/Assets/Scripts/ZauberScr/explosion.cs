using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

    public float DieTime;
    private void Start()
    {
        Invoke("Die", DieTime);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
