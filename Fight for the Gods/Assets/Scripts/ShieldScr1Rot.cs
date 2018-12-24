using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScr1Rot : MonoBehaviour {

    public float hp;
    public float Lifetime;

    

    private void Start()
    {
        Invoke("Die", Lifetime);
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Zauber1Gruen"))
        {
            Destroy(coll.gameObject);
        }
        else if (coll.CompareTag("Zauber1Blau"))
        {
            Destroy(coll.gameObject);
        }
        else if (coll.CompareTag("Zauber2Gruen"))
        {
            Destroy(gameObject);
        }
        else if (coll.CompareTag("Zauber2Rot"))
        {
            Destroy(coll.gameObject);
        }
        else if (coll.CompareTag("Zauber2Blau"))
        {
            Destroy(gameObject);
        }
        else if (coll.CompareTag("Zauber3Blau"))
        {
            Destroy(gameObject);
        }
        else if (coll.CompareTag("Zauber3Gruen"))
        {
            Destroy(gameObject);
        }
        else if (coll.CompareTag("Zauber3Rot"))
        {
            Destroy(coll.gameObject);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
