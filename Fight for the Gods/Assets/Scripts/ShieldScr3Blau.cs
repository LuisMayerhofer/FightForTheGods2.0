﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScr3Blau : MonoBehaviour
{
    public int HP;
    public float lifetime;

    private void Start()
    {
        Invoke("Die", lifetime);
    }

    public void GetDamage(int damage)
    {
        HP -= damage;
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Zauber1Gruen"))
        {
            Destroy(gameObject);
        }
        else if (coll.CompareTag("Zauber1Blau"))
        {
            Destroy(coll.gameObject);
        }
        else if (coll.CompareTag("Zauber1Rot"))
        {
            Destroy(gameObject);
        }
        else if (coll.CompareTag("Zauber2Gruen"))
        {
            Destroy(gameObject);
        }
        else if (CompareTag("Zauber2Rot"))
        {
            Destroy(coll.gameObject);
        }
        else if (coll.CompareTag("Zauber2Blau"))
        {
            Destroy(coll.gameObject);
        }
        
        else if (coll.CompareTag("Zauber3Gruen"))
        {
            Destroy(coll.gameObject);
        }
        else if (coll.CompareTag("Zauber3Rot"))
        {
            Destroy(coll.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
