using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header(" Settings ")]
    private Vector3 velocity;



    private void Update()
    {
        Move();
    }


    private void Move()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
