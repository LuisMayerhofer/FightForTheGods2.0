using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagramm : MonoBehaviour
{
    public float lifetime;
    void Start()
    {
        Invoke("Die", lifetime);
    }

   void Die()
    {
        Destroy(gameObject);
    }
}
