using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpZahlScr : MonoBehaviour
{
    private Animator anim;
    private float AnimationLength;
    void Awake()
    {
        GetComponent<Animator>();
        Invoke("Die", 0.14f);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
