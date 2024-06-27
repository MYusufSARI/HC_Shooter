using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header(" Settings ")]
    private Vector3 velocity;




    private void Start()
    {
        Destroy(gameObject, 3);
    }


    private void Update()
    {
        Move();
    }


    private void Move()
    {
        transform.position += velocity * Time.deltaTime;
    }


    public void Configure(Vector3 velocity)
    {
        this.velocity = velocity;
    }
}
