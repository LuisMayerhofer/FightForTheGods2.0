using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpwan : MonoBehaviour
{
    public Rigidbody2D Stone1;
    public Rigidbody2D Stone2;
    public Rigidbody2D Stone3;
    public Rigidbody2D Stone4;
    public Transform SpawnPosition;
    public float maxSpawnDelay;
    public float minSpeed;
    public float maxSpeed;

    private int StoneNumber;
    private float RespawnTime;

    private void Start()
    {
        Invoke("SpawnStone", 3);
        Invoke("SpawnStone", 10);
        Invoke("SpawnStone", 15);
        Invoke("SpawnStone", 40);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Stone"))
        {
            RespawnTime = Random.Range(0.5f, maxSpawnDelay);
            Invoke("SpawnStone", RespawnTime);
            Destroy(col.gameObject);
        }
    }

    void SpawnStone()
    {
        StoneNumber = Random.Range(1, 5);
        if (StoneNumber == 1)
        {
            Rigidbody2D StoneInstance1 = Instantiate(Stone1, new Vector2(SpawnPosition.position.x,SpawnPosition.position.y + Random.Range(-0.9f ,0.4f)), SpawnPosition.rotation) as Rigidbody2D;
            StoneInstance1.AddForce(new Vector2(1, 0) * Random.Range(minSpeed, maxSpeed));
        }
        else if (StoneNumber == 2)
        {
            Rigidbody2D StoneInstance2 = Instantiate(Stone2, new Vector2(SpawnPosition.position.x, SpawnPosition.position.y + Random.Range(-0.9f, 0.4f)), SpawnPosition.rotation) as Rigidbody2D;
            StoneInstance2.AddForce(new Vector2(1, 0) * Random.Range(minSpeed, maxSpeed));
        }
        else if (StoneNumber == 3)
        {
            Rigidbody2D StoneInstance3 = Instantiate(Stone3, new Vector2(SpawnPosition.position.x, SpawnPosition.position.y + Random.Range(-0.9f, 0.4f)), SpawnPosition.rotation) as Rigidbody2D;
            StoneInstance3.AddForce(new Vector2(1, 0) *Random.Range(minSpeed, maxSpeed));
        }
        else if (StoneNumber == 4)
        {
            Rigidbody2D StoneInstance4 = Instantiate(Stone4, new Vector2(SpawnPosition.position.x, SpawnPosition.position.y + Random.Range(-0.9f, 0.4f)), SpawnPosition.rotation) as Rigidbody2D;
            StoneInstance4.AddForce(new Vector2(1, 0) * Random.Range(minSpeed, maxSpeed));
        }
    }
}
