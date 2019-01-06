using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    public int HP;

    public float speed;
    public float DashDelay;
    public float DashForce;
    public float DashCD;

    public Slider healthBar;
    public Text PopUpZahl;
    public Canvas canvasParent;
    public GameObject rotationGameobject;
    public Transform PopUpPosition;

    private Rigidbody2D rb2d;
    private Animator Anim;
    private Transform Trans;    
    private Vector2 dir;

    private float DashRightTotal = 0;
    private float DashRightTime = 0;
    private float DashLeftTotal = 0;
    private float DashLeftTime = 0;
    private float curenthealth;
    float nextDashAllowedRight;
    float nextDashAllowedLeft;

    private bool Player2Won;
    private bool Xfirst, Yfirst;
    

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        curenthealth = HP;

        healthBar.value = CalculateHealth();
    }    

    


    public void GetDamage(int damage)
    {
        curenthealth -= damage;
        healthBar.value = CalculateHealth();
        Text PopUpInstance = Instantiate(PopUpZahl, PopUpPosition.position, rotationGameobject.transform.rotation);
        PopUpInstance.text = " " + damage;
        PopUpInstance.transform.SetParent(canvasParent.transform);
    }

    float CalculateHealth()
    {
        return curenthealth / HP;
    }

    private void Update()
    {
        //Controller

        float moveH = Input.GetAxis("HorizontalLS");
        float moveV = Input.GetAxis("VerticalLS");
        Debug.Log(moveH + " " + moveV);
        if (moveH == 0 && moveV == 0)
        {
            Anim.SetBool("RunBool", false);
            Anim.SetBool("Seitwaerts", false);
        }
        if (Mathf.Abs(moveV)> Mathf.Abs(moveH))
        {
            Anim.SetBool("RunBool", true);
            Anim.SetBool("Seitwaerts", false);
        }
        if (Mathf.Abs(moveV) < Mathf.Abs(moveH))
        {
            Anim.SetBool("RunBool", false);
            Anim.SetBool("Seitwaerts", true);
        }

        rb2d.AddForce(new Vector2(moveH, moveV) * speed);

        //Dash

        //Dash right
        
        if (Input.GetAxis("Right Trigger")>0.2)
        {
            if (Time.time > nextDashAllowedRight)
            {
                rb2d.AddForce(new Vector2(1, 0) * DashForce);
                nextDashAllowedRight = Time.time + DashCD;
            }
        }

        //Dash left
        if (Input.GetAxis("Left Trigger") > 0.2)
        {
            if (Time.time > nextDashAllowedLeft)
            {
                rb2d.AddForce(new Vector2(-1, 0) * DashForce);
                nextDashAllowedLeft = Time.time + DashCD;
            }
        }
       
        




        //------------------------------------------------------------------------------------
        //Movement

        float x = Input.GetAxisRaw("Horizontal");
             float y = Input.GetAxisRaw("Vertical");




             if (y != 0) // If the User is clicking on the vertical axis
             {
                 if (x == 0) // If he's not clicking on the horizontal axis:
                 {
                     Xfirst = false;
                     Yfirst = true; //Then it means he started by moving along the Y axis, and not along the X axis.
                     dir = Vector2.up * y;
                    
                 }
                 if (x != 0) // If he's clicking on the X axis (and on the Y axis at the same time)
                 {
                     if (Xfirst)//We check if he clicked first on X.
                     {
                         dir = Vector2.up * y; //If he did clicked first on X, then we go for Y , we change direction
                        
                     }
                     else
                     {
                         dir = Vector2.right * x;//If he did clicked first on Y, then we go for X.
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
                 }
                 if (y != 0)
                 {
                     if (Yfirst)
                     {
                         dir = Vector2.right * x;
                     }
                     else if (Xfirst)//Added one more check here. This way, if the player wasn't mooving, but acheive to hit X and Y and the same time, he will go on the Y axis by default.
                     {
                         dir = Vector2.up * y;

                     }
                 }
             }

             if (x == 0 && y == 0)
             {
                 dir = Vector2.zero;
             }

         rb2d.AddForce(dir * speed);

        //------------------------------------------------------------------------------------
        //Dash

        //Dash right
        if (Input.GetKeyDown("d"))
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
            rb2d.AddForce(new Vector2(1, 0) * DashForce);
        }
        if ((DashRightTotal == 2) && (DashRightTime >= DashDelay))
        {
            DashRightTime = 0;
            DashRightTotal = 0;
        }

        //Dash left
        if (Input.GetKeyDown("a"))
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
            rb2d.AddForce(new Vector2(-1, 0) * DashForce);

        }
        if ((DashLeftTotal == 2) && (DashLeftTime >= DashDelay))
        {
            DashLeftTime = 0;
            DashLeftTotal = 0;

        }

        /* float horizontal = Input.GetAxisRaw("Horizontal");
         float vertikal = Input.GetAxisRaw("Vertical");

         //AnimationRun
         if (vertikal > 0)
         {
             Anim.SetBool("RunBool", true);
         }
         else if ( vertikal < 0)
         {
             Anim.SetBool("RunBool", true);
         }
         else if(vertikal == 0)
         {
             Anim.SetBool("RunBool", false);
         }

         if (horizontal > 0)
         {
             Anim.SetBool("Seitwaerts", true);
         }
         else if (horizontal < 0)
         {
             Anim.SetBool("Seitwaerts", true);
         }
         else if (horizontal == 0)
         {
             Anim.SetBool("Seitwaerts", false);
         }*/


    }    
}
