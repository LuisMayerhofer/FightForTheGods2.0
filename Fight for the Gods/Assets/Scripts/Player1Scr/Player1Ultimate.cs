using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Ultimate : MonoBehaviour
{
    public GameObject pentagramm;
    public GameObject pentaIcon;
    public float PentagrammDauer;
    
    

    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sr;
    private GameObject UltiInstance;
    private bool UltiRunning = false;
    

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
            if ( !UltiRunning)
            {
                UltiRunning = true;
                pentaIcon.SendMessageUpwards("StartCD", UltiRunning = true);
                UltiInstance = Instantiate(pentagramm, transform.position, transform.rotation);
                Invoke("UltiEnde", PentagrammDauer);
               
            }
        }
    }

    void UltiEnde()
    {
        Destroy(UltiInstance);
        
    }
    public void NextUlti(bool NextUltiAllowed)
    {
        if (NextUltiAllowed)
        UltiRunning = false;
    }
}
