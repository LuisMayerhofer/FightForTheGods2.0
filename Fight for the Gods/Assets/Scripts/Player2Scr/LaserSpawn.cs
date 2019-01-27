using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour
{
    private RaycastHit2D hit;
    private LineRenderer laser;
    private bool LaserOn = false;
    public int damage = 1;
   

    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown("0"))
        {
            LaserOn = true;
        }

        if (LaserOn)
        {
            laser.SetPosition(0, transform.position);
            if (Physics2D.Raycast(transform.position, new Vector2(0, -1)))
            {
                hit = Physics2D.Raycast(transform.position, new Vector2(0, -1));
                laser.SetPosition(1, hit.point);
                if (hit.collider.CompareTag("Shield") || hit.collider.CompareTag("Player1") || hit.collider.CompareTag("Player2"))
                {
                    hit.collider.SendMessageUpwards("GetDamage", damage);
                }
                
            }
        }
    }
}
