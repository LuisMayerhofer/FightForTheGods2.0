using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteinBallScr : MonoBehaviour
{
    public int damage;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Shield"))
        {
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("Player1") || col.CompareTag("Player2"))
        {
            col.SendMessageUpwards("GetDamage", damage);
        }
    }

}
