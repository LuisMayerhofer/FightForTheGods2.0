﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltiIcon1Scr : MonoBehaviour
{
    public GameObject Player;
    public float ultiReloadSpeed;
    public ParticleSystem StartParticleSystem;
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
            tmp = sr.color;
            tmp.a = 0;
            sr.color = tmp;
            Invoke("StopParticle", 0.001f);
            startCD = true;
        }
    }

    void Update()
    {
        if (startCD && Time.time >= plusOneSecond )
        {
            
            tmp.a += ultiReloadSpeed;
            sr.color = tmp;
            plusOneSecond = Time.time + 1;
        }
        if (tmp.a >= 1)
        {
            particlesystem.Play(true);
            
            
            Player.SendMessageUpwards("NextUlti", NextUltiAllowed = true);
            startCD = false;
            tmp.a = 0;
        }
    }

    void StopParticle()
    {
        particlesystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        
    }

}
