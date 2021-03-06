﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2Scr : MonoBehaviour
{

    
    public int HPP2;

    public float speedP2;
    public float DashDelay;
    public float DashForce;

    public Slider healthBar;
    public Text PopUpZahl;
    public Canvas canvasParent;
    public GameObject rotationGameobject;
    public Transform PopUpPosition;

    private Rigidbody2D rb2d;
    private Animator Anim;
    private Transform Trans;
    private Vector2 dir;

    private bool Xfirst, Yfirst;
    private bool Player2Won;

    private float DashRightTotal = 0;
    private float DashRightTime = 0;
    private float DashLeftTotal = 0;
    private float DashLeftTime = 0;   
    private float currenthealth;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        currenthealth = HPP2;

        healthBar.value = CalculateHealth();
    }


    float CalculateHealth()
    {
        return currenthealth / HPP2;
    }

    public void GetDamage(int damage)
    {
       currenthealth -= damage;
       healthBar.value = CalculateHealth();
       Text PopUpInstance = Instantiate(PopUpZahl, PopUpPosition.position, rotationGameobject.transform.rotation);
        PopUpInstance.text = " " + damage;
        PopUpInstance.transform.SetParent(canvasParent.transform);
      
    }

    private void Update()
    {
        //HP
        if (currenthealth <= 0)
        {

            SceneManager.LoadScene(2);
            Destroy(gameObject);
        }

        //------------------------------------------------------------------------------------
        //Movement

        float x = Input.GetAxisRaw("HorizontalP2");
        float y = Input.GetAxisRaw("VerticalP2");




        if (y != 0) // If the User is clicking on the vertical axis
        {
            if (x == 0) // If he's not clicking on the horizontal axis:
            {
                Xfirst = false;
                Yfirst = true; //Then it means he started by moving along the Y axis, and not along the X axis.
                dir = Vector2.up * y;
                Anim.SetBool("RunBool", true);
                Anim.SetBool("Seitwaerts", false);
                Debug.Log(Anim.GetCurrentAnimatorStateInfo(0).length);
            }
            if (x != 0) // If he's clicking on the X axis (and on the Y axis at the same time)
            {
                if (Xfirst)//We check if he clicked first on X.
                {
                    dir = Vector2.up * y; //If he did clicked first on X, then we go for Y , we change direction
                    Anim.SetBool("RunBool", true);
                    Anim.SetBool("Seitwaerts", false);
                }
                else
                {
                    dir = Vector2.right * x;//If he did clicked first on Y, then we go for X.
                    Anim.SetBool("RunBool", false);
                    Anim.SetBool("Seitwaerts", true);


                }


            }
        }

        if (x != 0)//This is the same thing, but the other way around.
        {
            if (y == 0)
            {
                Xfirst = true;
                Yfirst = false;//In fact this way, we set Yfirst to false only when the user releases the Y button.
                dir = Vector2.right * x;
                Anim.SetBool("RunBool", false);
                Anim.SetBool("Seitwaerts", true);
            }
            if (y != 0)
            {
                if (Yfirst)
                {
                    dir = Vector2.right * x;
                    Anim.SetBool("RunBool", false);
                    Anim.SetBool("Seitwaerts", true);
                }
                else if (Xfirst)//Added one more check here. This way, if the player wasn't mooving, but acheive to hit X and Y and the same time, he will go on the Y axis by default.
                {
                    dir = Vector2.up * y;
                    Anim.SetBool("RunBool", true);
                    Anim.SetBool("Seitwaerts", false);
                }
            }
        }

        if (x == 0 && y == 0)
        {
            dir = Vector2.zero;
            Anim.SetBool("RunBool", false);
            Anim.SetBool("Seitwaerts", false);
        }

        rb2d.AddForce(dir * speedP2);

       //--------------------------------------------------------------------------------
       //Dash


        //Dash right
        if (Input.GetKeyDown("l"))
        {
            DashRightTotal += 1;
        }
        if ((DashRightTotal == 1) && (DashRightTime < DashDelay))
            DashRightTime += Time.deltaTime;
        if ((DashRightTotal == 1) && (DashRightTime >= DashDelay))
        {
            DashRightTime = 0;
            DashRightTotal = 0;
        }
        if ((DashRightTotal == 2) && (DashRightTime < DashDelay))
        {
            DashRightTotal = 0;
            rb2d.AddForce(new Vector2(1, 0)*DashForce);
        }
        if ((DashRightTotal == 2) && (DashRightTime >= DashDelay))
        {
            DashRightTime = 0;
            DashRightTotal = 0;
        }

        //Dash left
        if (Input.GetKeyDown("j"))
        {
            DashLeftTotal += 1;
            
        }
        if ((DashLeftTotal == 1) && (DashLeftTime < DashDelay))
            DashLeftTime += Time.deltaTime;
            
        if ((DashRightTotal == 1) && (DashLeftTime >= DashDelay))
        {
            DashLeftTime = 0;
            DashLeftTotal = 0;
            
        }
        if ((DashLeftTotal == 2) && (DashLeftTime < DashDelay))
        {
            DashLeftTotal = 0;
            rb2d.AddForce(new Vector2(-1, 0)*DashForce);
            
        }
        if ((DashLeftTotal == 2) && (DashLeftTime >= DashDelay))
        {
            DashLeftTime = 0;
            DashLeftTotal = 0;
            
        }
    }
}