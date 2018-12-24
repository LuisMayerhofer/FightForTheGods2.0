using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public GameObject explosion;
    public int damage;
    public int BounceCountMax;

    private int BounceCount = 0;

    void OnTriggerEnter2D (Collider2D col)
    {

        if (col.isTrigger != true && (col.CompareTag("Player1") || col.CompareTag("Player2")))
        {
            col.SendMessageUpwards("GetDamage", damage);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if(!col.isTrigger && col.CompareTag("Shield"))
        {
            col.SendMessageUpwards("GetDamage", damage);
        }
        else if (col.CompareTag("Destroy"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (col.isTrigger != true)
        {
            BounceCount += 1;
        }
        
    }

    private void Update()
    {
        if (BounceCount > BounceCountMax)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
