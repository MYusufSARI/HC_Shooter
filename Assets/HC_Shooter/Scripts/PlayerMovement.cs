using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float moveSpeed;



    private void Start()
    {
        Application.targetFrameRate = 60;
    }


    private void Update()
    {
        Move();
    }


    private void Move()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
}
