using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum State
    {
        Idle,
        Run,
    };

    private State state;

    [Header("Settings")]
    [SerializeField]
    private float moveSpeed;


    [Header(" Elements ")]
    [SerializeField]
    private PlayerAnimator playerAnimator;



    private void Start()
    {
        Application.targetFrameRate = 60;

        state = State.Idle;

        StartRunning();
    }


    private void Update()
    {
        ManageState();
    }


    private void ManageState()
    {
        switch (state)
        {
            case State.Idle:
                break;

            case State.Run:
                Move();
                break;
        }
    }



    private void StartRunning()
    {
        playerAnimator.PlayRunAnimator();
    }


    private void Move()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
}
