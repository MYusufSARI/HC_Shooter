using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private LayerMask enemiesMask;
    [SerializeField] private float detectionRadius;
    private Vector3 velocity;




    private void Start()
    {
        Destroy(gameObject, 3);
    }


    private void Update()
    {
        Move();

        CheckForEnemies();
    }

   

    private void Move()
    {
        transform.position += velocity * Time.deltaTime;
    }


    public void Configure(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    private void CheckForEnemies()
    {
        Collider[] detectedEnemies = Physics.OverlapSphere(transform.position, detectionRadius, enemiesMask);

        foreach (Collider enemyCollider in detectedEnemies)
        {
            Destroy(enemyCollider.gameObject);
        }
    }
}
