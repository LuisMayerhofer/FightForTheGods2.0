using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    public float HP;
    public Rigidbody2D Ball;
    public Transform BallAbschussPosition;
    public float ShootingForce;


    //Schaden
    public void GetDamage(int damage)
    {
        HP -= damage;
        
    }

   private void Update()
    {
        if (HP <= 0)
            Destroy(gameObject);

        if (Input.GetKeyDown("1"))
        {
            Rigidbody2D BallInstance = Instantiate(Ball, BallAbschussPosition.position, transform.rotation);
            BallInstance.AddForce(new Vector2(0, -1)*ShootingForce);

        }
    }
}
