using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum State
    {
        Idle,
        Run,
        Warzone,
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
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartRunning();
        }

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

            case State.Warzone:
                break;
        }
    }



    private void StartRunning()
    {
        state = State.Run;
        
        playerAnimator.PlayRunAnimator();
    }


    private void Move()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }


    public void EnteredWarzoneCallback(Warzone warzone)
    {
        Debug.Log("Entered Warzone");
    }
}
