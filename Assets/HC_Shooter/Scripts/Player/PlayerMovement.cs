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
        Dead
    };


    [Header(" Elements ")]
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private CharacterIK playerIK;
    [SerializeField] private CharacterRagdoll characterRagdoll;


    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float slowMoScale;
    [SerializeField] private Transform enemyTarget;


    private State state;
    private Warzone currentWarzone;


    [Header(" Spline Settings ")]
    private float warzoneTimer;


    [Header(" Actions ")]
    public static Action onEnteredWarzone;
    public static Action onExitedWarzone;
    public static Action onDied;



    private void Awake()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }


    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;

    }


    private void Start()
    {
        Application.targetFrameRate = 60;

        state = State.Idle;
    }


    private void Update()
    {
        ManageState();
    }


    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Game:
                StartRunning();
                break;
        }
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

        currentWarzone.StartAnimatingIKTarget();

        warzoneTimer = 0;

        playerAnimator.Play(currentWarzone.GetAnimationToPlay());

        Time.timeScale = slowMoScale;

        int initialValueOfFixedTimeScale = 50;
        Time.fixedDeltaTime = slowMoScale / initialValueOfFixedTimeScale;

        playerIK.ConfigureIK(currentWarzone.GetIKTarget());

        onEnteredWarzone?.Invoke();

        Debug.Log("Entered Warzone !");


    }


    private void ManageWarzoneState()
    {
        warzoneTimer += Time.deltaTime;

        float splinePercent = warzoneTimer / currentWarzone.GetDuration();
        transform.position = currentWarzone.GetPlayerSpline().EvaluatePosition(splinePercent);

        if (splinePercent >= 1)
        {
            ExitWarzone();
        }
    }


    private void ExitWarzone()
    {
        currentWarzone = null;

        state = State.Run;
        playerAnimator.Play("Run");

        Time.timeScale = 1;

        int initialValueOfFixedTimeScale = 50;
        Time.fixedDeltaTime = 1f / initialValueOfFixedTimeScale;

        playerIK.DisableIK();


        onExitedWarzone?.Invoke();

    }


    public Transform GetEnemyTarget()
    {
        return enemyTarget;
    }


    public void TakeDamage()
    {
        state = State.Dead;

        characterRagdoll.Ragdollify();

        int initialValueOfFixedTimeScale = 50;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 1f / initialValueOfFixedTimeScale;

        onDied?.Invoke();

        GameManager.instance.SetGameState(GameState.GameOver);
    }
}
