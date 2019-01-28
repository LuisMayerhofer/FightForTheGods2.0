using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour
{
    private RaycastHit2D hit;
    private LineRenderer laser;
    private bool LaserOn = false;
    private bool UltiRunning = false;

    public GameObject LaserIcon;
    public int damage = 1;
    public float LaserDuration;
   

    void Start()
    {
        laser = GetComponent<LineRenderer>();
        laser.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug
        hit = Physics2D.Raycast(transform.position, new Vector2(0, -1));
        Debug.DrawLine(transform.position, hit.point);

        //Ulti starten wenn !UltiRunning
        if (Input.GetKeyDown("o")&& !UltiRunning)
        {
            UltiRunning = true;
            LaserOn = true;
            Invoke("StopLaser", LaserDuration);
            LaserIcon.SendMessageUpwards("StartCD", UltiRunning = true);
        }

        if (LaserOn)
        {
            laser.SetPosition(0, transform.position);
            if (Physics2D.Raycast(transform.position, new Vector2(0, -1)))
            {
                
                hit = Physics2D.Raycast(transform.position, new Vector2(0, -1));
                
                laser.SetPosition(1, hit.point);
                laser.enabled = true;

                
                Debug.Log("LaserEnabled");
                if (hit.collider.CompareTag("Shield") || hit.collider.CompareTag("Player1") || hit.collider.CompareTag("Player2"))
                {
                    hit.collider.SendMessageUpwards("GetDamage", damage);
                }
                
            }
        }
    }

    void StopLaser()
    {
        LaserOn = false;
        laser.enabled = false;
    }

    public void NextUlti(bool NextUltiAllowed)
    {
        if (NextUltiAllowed)
            UltiRunning = false;
    }
}
