﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    private AudioSource audiosource;
    private bool playingSong1 = false;
    private bool playingSong2 = false;
    private bool playingSong3 = false;
    private int StartSong;

    public float starttime;
    public AudioClip Song1;
    public AudioClip Song2;
    public AudioClip Song3;



    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        StartSong = Random.Range(1, 3);

        if (StartSong == 1)
            audiosource.clip = Song1;
        else if (StartSong == 2)
            audiosource.clip = Song2;
        else
            audiosource.clip = Song3;
    }

    private void Start()
    {
        audiosource.Play();
        playingSong1 = true;
    }

    private void Update()
    {
        if (!audiosource.isPlaying)
        {
            if (playingSong1)
            {
                playingSong2 = true;
                playingSong1 = false;
                playingSong3 = false;
                audiosource.clip = Song2;
                audiosource.Play();

            }
            else if (playingSong2)
            {
                playingSong2 = false;
                playingSong1 = false;
                playingSong3 = true;
                audiosource.clip = Song3;
                audiosource.Play();

            }
            else if (playingSong3)
            {
                playingSong2 = false;
                playingSong1 = true;
                playingSong3 = false;
                audiosource.clip = Song1;
                audiosource.Play();

            }
        }
    }

    
}
