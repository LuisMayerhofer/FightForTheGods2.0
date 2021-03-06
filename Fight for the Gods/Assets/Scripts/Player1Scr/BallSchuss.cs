﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSchuss : MonoBehaviour {

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

    public float ShootingForce;
    public float Zauber1CD;
    public float Zauber2CD;
    public float Zauber3CD;

    public float Shield1CD;
    public float Shield2CD;
    public float Shield3CD;

    public Transform AbschussPosition;
    public SpriteRenderer sr;

    private Rigidbody2D rb2d;

    public Sprite Zauber1Equipped;
    public  Sprite Zauber2Equipped;
    public Sprite Zauber3Equipped;

    private float nextZauber1Allowed;
    private float nextZauber2Allowed;
    private float nextZauber3Allowed;

    private float nextShield1Allowed;
    private float nextShield2Allowed;
    private float nextShield3Allowed;

    private bool facingRight;
    private bool facingLeft;
    private bool facingForwards;
    private bool facingBackwards;
    private bool Zauber1 = true;
    private bool Zauber2 = false;
    private bool Zauber3 = false;
    private bool Capslock = false;
    private bool RechterBumper = false;

    private Vector2 ShootForwards = new Vector2(0, 1);



    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
   



    void Update () {

        //CapsLock
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            Capslock = true;
        }
        if (Input.GetKeyUp(KeyCode.CapsLock))
            Capslock = false;

        //RightBumper
        if (Input.GetButtonDown("Right Bumper"))
            RechterBumper = true;
        if (Input.GetButtonUp("Right Bumper"))
            RechterBumper = false;

        //Facing
        /*if (Input.GetButtonDown("right"))
        {
            facingRight = true;
            facingLeft = false;
            facingForwards = false;
            facingBackwards = false;
        }
        
        if (Input.GetButtonDown("left"))
        {
            facingRight = false;
            facingLeft = true;
            facingForwards = false;
            facingBackwards = false;
        }
            
        if (Input.GetButtonDown("up"))
        {
            facingRight = false;
            facingLeft = false;
            facingForwards = true;
            facingBackwards = false;
        }

        if (Input.GetButtonDown("down"))
        {
            facingRight = false;
            facingLeft = false;
            facingForwards = false;
            facingBackwards = true;
        }*/


            // Zauber
            /* R = 1
             * T = 2
             * Z = 3
             * 
             * F = Rot
             * G = Gruen
             * H = Blau
            */

            /*if (Input.GetKeyDown("r"))
            {
                Zauber1 = true;
                Zauber2 = false;
                Zauber3 = false;
                sr.sprite = Zauber1Equipped;
            }
            if (Input.GetKeyDown("t"))
            {
                Zauber1 = false;
                Zauber2 = true;
                Zauber3 = false;
                sr.sprite = Zauber2Equipped;
            }
            if (Input.GetKeyDown("z"))
            {
                Zauber1 = false;
                Zauber2 = false;
                Zauber3 = true;
                sr.sprite = Zauber3Equipped;
            }*/

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("Left Bumper"))
        {
            if(Zauber1 == true && Zauber2 == false && Zauber3 == false)
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
            else if(Zauber1 == false && Zauber2 == false && Zauber3 == true)
            {
                Zauber1 = true;
                Zauber2 = false;
                Zauber3 = false;
                sr.sprite = Zauber1Equipped;
            }
        }

        if (!Capslock && !RechterBumper)
        {
            //Rot
            if ((Input.GetKeyDown("f") || Input.GetButtonDown("B Button")) && Zauber1 == true)
        {
            if (Time.time > nextZauber1Allowed)
            {
                Rigidbody2D ZauberInstance;
                ZauberInstance = Instantiate(ZauberROT1, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                ZauberInstance.AddForce(ShootForwards * ShootingForce);
                nextZauber1Allowed = Time.time + Zauber1CD;
            }
        }
        else if ((Input.GetKeyDown("f") || Input.GetButtonDown("B Button")) && Zauber2 == true)
        {
            if (Time.time > nextZauber2Allowed)
            {
                Rigidbody2D ZauberInstance;
                ZauberInstance = Instantiate(ZauberROT2, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                ZauberInstance.AddForce(ShootForwards * ShootingForce);
                nextZauber2Allowed = Time.time + Zauber2CD;
            }
        }
        else if ((Input.GetKeyDown("f") || Input.GetButtonDown("B Button")) && Zauber3 == true)
        {
            if (Time.time > nextZauber3Allowed)
            {
                Rigidbody2D ZauberInstance;
                ZauberInstance = Instantiate(ZauberROT3, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                ZauberInstance.AddForce(ShootForwards * ShootingForce);
                nextZauber3Allowed = Time.time + Zauber3CD;
            }
        }

        //Gruen
        if ((Input.GetKeyDown("g") || Input.GetButtonDown("A Button")) && Zauber1 == true)
        {
            if (Time.time > nextZauber1Allowed)
            {
                Rigidbody2D ZauberInstance;
                ZauberInstance = Instantiate(ZauberGRUEN1, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                ZauberInstance.AddForce(ShootForwards * ShootingForce);
                nextZauber1Allowed = Time.time + Zauber1CD;
            }
        }
        else if ((Input.GetKeyDown("g") || Input.GetButtonDown("A Button")) && Zauber2 == true)
        {
            if (Time.time > nextZauber2Allowed)
            {
                Rigidbody2D ZauberInstance;
                ZauberInstance = Instantiate(ZauberGRUEN2, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                ZauberInstance.AddForce(ShootForwards * ShootingForce);
                nextZauber2Allowed = Time.time + Zauber2CD;
            }
        }
        else if ((Input.GetKeyDown("g") || Input.GetButtonDown("A Button")) && Zauber3 == true)
        {
            if (Time.time > nextZauber3Allowed)
            {
                Rigidbody2D ZauberInstance;
                ZauberInstance = Instantiate(ZauberGRUEN3, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                ZauberInstance.AddForce(ShootForwards * ShootingForce);
                nextZauber3Allowed = Time.time + Zauber3CD;
            }
        }

        
            //Blau
            if ((Input.GetKeyDown("h") || Input.GetButtonDown("X Button")) && Zauber1 == true)
        {
            if (Time.time > nextZauber1Allowed)
            {
                Rigidbody2D ZauberInstance;
                ZauberInstance = Instantiate(ZauberBLAU1, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                ZauberInstance.AddForce(ShootForwards * ShootingForce);
                nextZauber1Allowed = Time.time + Zauber1CD;
            }
        }
        else if ((Input.GetKeyDown("h") || Input.GetButtonDown("X Button")) && Zauber2 == true)
        {
            if (Time.time > nextZauber2Allowed)
            {
                Rigidbody2D ZauberInstance;
                ZauberInstance = Instantiate(ZauberBLAU2, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                ZauberInstance.AddForce(ShootForwards * ShootingForce);
                nextZauber2Allowed = Time.time + Zauber2CD;
            }
        }
        else if ((Input.GetKeyDown("h") || Input.GetButtonDown("X Button")) && Zauber3 == true)
        {
            if (Time.time > nextZauber3Allowed)
            {
                Rigidbody2D ZauberInstance;
                ZauberInstance = Instantiate(ZauberBLAU3, AbschussPosition.position, transform.rotation) as Rigidbody2D;
                ZauberInstance.AddForce(ShootForwards * ShootingForce);
                nextZauber3Allowed = Time.time + Zauber3CD;
            }
        }


            //Shields
        }
        else if (Capslock || RechterBumper)
        {
            //Rot
            if ((Input.GetKeyDown("f") || Input.GetButtonDown("B Button")) && Zauber1 == true)
            {
                if (Time.time > nextShield1Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldROT1, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield1Allowed = Time.time + Shield1CD;
                }
            }
            else if ((Input.GetKeyDown("f") || Input.GetButtonDown("B Button")) && Zauber2 == true)
            {
                if (Time.time > nextShield2Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldROT2, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield2Allowed = Time.time + Shield2CD;
                }
            }
            else if ((Input.GetKeyDown("f") || Input.GetButtonDown("B Button")) && Zauber3 == true)
            {
                if (Time.time > nextShield3Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldROT3, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield3Allowed = Time.time + Shield3CD;
                }
            }

            //Gruen
            if ((Input.GetKeyDown("g") || Input.GetButtonDown("A Button")) && Zauber1 == true)
            {
                if (Time.time > nextShield1Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldGRUEN1, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield1Allowed = Time.time + Shield1CD;
                }
            }
            else if ((Input.GetKeyDown("g") || Input.GetButtonDown("A Button")) && Zauber2 == true)
            {
                if (Time.time > nextShield2Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldGRUEN2, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield2Allowed = Time.time + Shield2CD;
                }
            }
            else if ((Input.GetKeyDown("g") || Input.GetButtonDown("A Button")) && Zauber3 == true)
            {
                if (Time.time > nextShield3Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldGRUEN3, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield3Allowed = Time.time + Shield3CD;
                }
            }

            //Blau
            if ((Input.GetKeyDown("h") || Input.GetButtonDown("X Button")) && Zauber1 == true)
            {
                if (Time.time > nextShield1Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldBLAU1, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield1Allowed = Time.time + Shield1CD;
                }
            }
            else if ((Input.GetKeyDown("h") || Input.GetButtonDown("X Button")) && Zauber2 == true)
            {
                if (Time.time > nextShield2Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldBLAU2, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield2Allowed = Time.time + Shield2CD;
                }
            }
            else if ((Input.GetKeyDown("h") || Input.GetButtonDown("X Button")) && Zauber3 == true)
            {
                if (Time.time > nextShield3Allowed)
                {
                    Rigidbody2D ZauberInstance;
                    ZauberInstance = Instantiate(ShieldBLAU3, AbschussPosition.position, transform.rotation) as Rigidbody2D;

                    nextShield3Allowed = Time.time + Shield3CD;
                }
            }
        }



        /*if (facingRight == true)
            BallInstance.AddForce(ShootRight * ShootingForce);
        else if (facingLeft == true)
            BallInstance.AddForce(ShootLeft * ShootingForce);

        if (facingForwards == true)
            BallInstance.AddForce(ShootForwards * ShootingForce);
        else if (facingBackwards == true)
            BallInstance.AddForce(ShootBackwards * ShootingForce);
            
            */
    }
}
