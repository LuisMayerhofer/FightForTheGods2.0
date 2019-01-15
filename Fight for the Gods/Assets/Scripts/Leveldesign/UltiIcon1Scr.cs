using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltiIcon1Scr : MonoBehaviour
{
    public GameObject Player1;
    private SpriteRenderer sr;
    private ParticleSystem particlesystem;
    private Color tmp;
    private bool startCD = false;
    private float plusOneSecond;
    private bool NextUltiAllowed;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        particlesystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    public void StartCD(bool UltiRunning)
    {
        if (UltiRunning)
        {
            Debug.Log("UltiRunning");
            tmp = sr.color;
            tmp.a = 0;
            sr.color = tmp;
            startCD = true;
        }
    }

    void Update()
    {
        if (startCD && Time.time >= plusOneSecond )
        {
            tmp.a += 0.2f;
            sr.color = tmp;
            plusOneSecond = Time.time + 1;
        }
        if (tmp.a == 1)
        {
            particlesystem.Play();
            Invoke("StopParticle", 1);
            Player1.SendMessageUpwards("NextUlti", NextUltiAllowed = true);
            startCD = false;
        }
    }

    void StopParticle()
    {
        particlesystem.Stop();
    }

}
