using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2SchussScr : MonoBehaviour
{

    public Rigidbody2D ZauberROT1;
    public Rigidbody2D ZauberGRUEN1;
    public Rigidbody2D ZauberBLAU1;
    public Rigidbody2D ZauberROT2;
    public Rigidbody2D ZauberGRUEN2;
    public Rigidbody2D ZauberBLAU2;
    public Rigidbody2D ZauberROT3;
    public Rigidbody2D ZauberGRUEN3;
    public Rigidbody2D ZauberBLAU3;

    public Rigidbody2D ShieldROT1;
    public Rigidbody2D ShieldGRUEN1;
    public Rigidbody2D ShieldBLAU1;
    public Rigidbody2D ShieldROT2;
    public Rigidbody2D ShieldGRUEN2;
    public Rigidbody2D ShieldBLAU2;
    public Rigidbody2D ShieldROT3;
    public Rigidbody2D ShieldGRUEN3;
    public Rigidbody2D ShieldBLAU3;

    public float Zauber1CD;
    public float Zauber2CD;
    public float Zauber3CD;

    public float Shield1CD;
    public float Shield2CD;
    public float Shield3CD;

    public float ShootingForce;
    public Transform AbschussPosition;
    public SpriteRenderer sr;

    private Rigidbody2D rb2d;
    public Sprite Zauber1Equipped;
    public Sprite Zauber2Equipped;
    public Sprite Zauber3Equipped;

    private float nextZauber1Allowed;
    private float nextZauber2Allowed;
    private float nextZauber3Allowed;

    private float nextShield1Allowed;
    private float nextShield2Allowed;
    private float nextShield3Allowed;

    private bool Zauber1 = true;
    private bool Zauber2 = false;
    private bool Zauber3 = false;

    private bool space = false;

    private Vector2 ShootBackwards = new Vector2(0, -1);



    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            space = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            space = false;
        
        // Zauber
        /* o = 1
         * p = 2
         * ü = 3
         * 
         * ö = Rot
         * ä = Gruen
         * # = Blau
         * 
         * KeyCodes:
         * ü = Semicolon
         * ö = BackQuote
         * ä = Quote

        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(kcode))
                Debug.Log("KeyCode down: " + kcode);
        }*/


        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (Zauber1 == true && Zauber2 == false && Zauber3 == false)
            {
                Zauber1 = false;
                Zauber2 = true;
                Zauber3 = false;
                sr.sprite = Zauber2Equipped;
            }
            else if (Zauber1 == false && Zauber2 == true && Zauber3 == false)
            {
                Zauber1 = false;
                Zauber2 = false;
                Zauber3 = true;
                sr.sprite = Zauber3Equipped;
            }
            else if (Zauber1 == false && Zauber2 == false && Zauber3 == true)
            {
                Zauber1 = true;
                Zauber2 = false;
                Zauber3 = false;
                sr.sprite = Zauber1Equipped;
            }
        }

        
        if (!space)
        {
            //Rot
            if (Input.GetKeyDown(KeyCode.BackQuote) && Zauber1 == true)
            {
                if (Time.time > nextZauber1Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ZauberROT1, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                    ZauberInstance.AddForce(ShootBackwards * ShootingForce);
                    nextZauber1Allowed = Time.time + Zauber1CD;
                }
            }
            else if (Input.GetKeyDown(KeyCode.BackQuote) && Zauber2 == true)
            {
                if (Time.time > nextZauber2Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ZauberROT2, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                    ZauberInstance.AddForce(ShootBackwards * ShootingForce);
                    nextZauber2Allowed = Time.time + Zauber2CD;
                }
            }
            else if (Input.GetKeyDown(KeyCode.BackQuote) && Zauber3 == true)
            {
                if (Time.time > nextZauber3Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ZauberROT3, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                    ZauberInstance.AddForce(ShootBackwards * ShootingForce);
                    nextZauber3Allowed = Time.time + Zauber3CD;
                }
            }

            //Gruen
            if (Input.GetKeyDown(KeyCode.Quote) && Zauber1 == true)
            {
                if (Time.time > nextZauber1Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ZauberGRUEN1, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                    ZauberInstance.AddForce(ShootBackwards * ShootingForce);
                    nextZauber1Allowed = Time.time + Zauber1CD;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Quote) && Zauber2 == true)
            {
                if (Time.time > nextZauber2Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ZauberGRUEN2, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                    ZauberInstance.AddForce(ShootBackwards * ShootingForce);
                    nextZauber2Allowed = Time.time + Zauber2CD;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Quote) && Zauber3 == true)
            {
                if (Time.time > nextZauber3Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ZauberGRUEN3, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                    ZauberInstance.AddForce(ShootBackwards * ShootingForce);
                    nextZauber3Allowed = Time.time + Zauber3CD;
                }
            }

            //Blau
            if (Input.GetKeyDown(KeyCode.Slash) && Zauber1 == true)
            {
                if (Time.time > nextZauber1Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ZauberBLAU1, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                    ZauberInstance.AddForce(ShootBackwards * ShootingForce);
                    nextZauber1Allowed = Time.time + Zauber1CD;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Slash) && Zauber2 == true)
            {
                if (Time.time > nextZauber2Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ZauberBLAU2, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                    ZauberInstance.AddForce(ShootBackwards * ShootingForce);
                    nextZauber2Allowed = Time.time + Zauber2CD;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Slash) && Zauber3 == true)
            {
                if (Time.time > nextZauber3Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ZauberBLAU3, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                    ZauberInstance.AddForce(ShootBackwards * ShootingForce);
                    nextZauber3Allowed = Time.time + Zauber3CD;
                }
            }
        }
        else
        {
            //Rot
            if (Input.GetKeyDown(KeyCode.BackQuote) && Zauber1 == true)
            {
                if (Time.time > nextShield1Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldROT1, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                    
                    nextShield1Allowed = Time.time + Shield1CD;
                }
            }
            else if (Input.GetKeyDown(KeyCode.BackQuote) && Zauber2 == true)
            {
                if (Time.time > nextShield2Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldROT2, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                    
                    nextShield2Allowed = Time.time + Shield2CD;
                }
            }
            else if (Input.GetKeyDown(KeyCode.BackQuote) && Zauber3 == true)
            {
                if (Time.time > nextShield3Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldROT3, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield3Allowed = Time.time + Shield3CD;
                }
            }

            //Gruen
            if (Input.GetKeyDown(KeyCode.Quote) && Zauber1 == true)
            {
                if (Time.time > nextShield1Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldGRUEN1, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                    
                    nextShield1Allowed = Time.time + Shield1CD;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Quote) && Zauber2 == true)
            {
                if (Time.time > nextShield2Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldGRUEN2, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield2Allowed = Time.time + Shield2CD;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Quote) && Zauber3 == true)
            {
                if (Time.time > nextShield3Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldGRUEN3, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield3Allowed = Time.time + Shield3CD;
                }
            }

            //Blau
            if (Input.GetKeyDown(KeyCode.Slash) && Zauber1 == true)
            {
                if (Time.time > nextShield1Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldBLAU1, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield1Allowed = Time.time + Shield1CD;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Slash) && Zauber2 == true)
            {
                if (Time.time > nextShield2Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldBLAU2, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield2Allowed = Time.time + Shield2CD;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Slash) && Zauber3 == true)
            {
                if (Time.time > nextShield3Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldBLAU3, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield3Allowed = Time.time + Shield3CD;
                }
            }
        }
    }
}
