using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed;
    public int HP;

    private Rigidbody2D rb2d;
    private Animator Anim;
    private Transform Trans;
    private bool Xfirst, Yfirst;
    private Vector2 dir;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }    

    


    public void GetDamage(int damage)
    {
        HP -= damage;
    }


    private void Update()
    {
        float moveH = Input.GetAxis("HorizontalLS");
        float moveV = Input.GetAxis("VerticalLS");


        rb2d.AddForce(new Vector2(moveH, moveV) * speed);

        if (HP <= 0)
            Destroy(gameObject);





        /*
             float x = Input.GetAxisRaw("Horizontal");
             float y = Input.GetAxisRaw("Vertical");




             if (y != 0) // If the User is clicking on the vertical axis
             {
                 if (x == 0) // If he's not clicking on the horizontal axis:
                 {
                     Xfirst = false;
                     Yfirst = true; //Then it means he started by moving along the Y axis, and not along the X axis.
                     dir = Vector2.up * y;
                     Anim.SetBool("RunBool", true);
                     Anim.SetBool("Seitwaerts", false);
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

         rb2d.AddForce(dir * speed);



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



        /*if (Input.GetKeyDown("space"))
        {
            Instantiate(Block, BlockPosition.position, BlockPosition.rotation);
        }
        */





        //-------------------------------------------------------------------









        //Unnötig

        //Rotation
        /*if (Input.GetButtonDown("right"))
        {
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.back);
        }
                

        if (Input.GetButtonDown("left"))
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.back);
        }
                

        if (Input.GetButtonDown("down"))
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.back);
        }

        if (Input.GetButtonDown("up"))
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.back);
        }  */
    }    
}
