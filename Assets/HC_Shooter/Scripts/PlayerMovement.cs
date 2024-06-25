using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

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

    [Header(" Spline Settings ")]
    private float warzoneTimer;


    private Warzone currentWarzone;




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
                ManageWarzoneState();
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
        if (currentWarzone != null)
            return;

        state = State.Warzone;
        currentWarzone = warzone;

        warzoneTimer = 0;

        playerAnimator.Play(currentWarzone.GetAnimationToPlay(), currentWarzone.GetAnimatorSpeed());

        Debug.Log("Entered Warzone !");
    }


    private void ManageWarzoneState()
    {
        warzoneTimer += Time.deltaTime;

        float splinePercent = warzoneTimer / currentWarzone.GetDuration();
        transform.position = currentWarzone.GetPlayerSpline().EvaluatePosition(splinePercent);
    }
}
