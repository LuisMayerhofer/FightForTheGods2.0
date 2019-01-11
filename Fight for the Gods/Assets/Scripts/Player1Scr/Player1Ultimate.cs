using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Ultimate : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sr;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") || Input.GetButtonDown("Y Button"))
        {

        }
    }
}
