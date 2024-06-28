using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum State
    {
        Alive,
        Dead
    }

    private State state;

    [Header(" Elements ")]
    [SerializeField] private EnemyShooter enemyShooter;
    [SerializeField] private CharacterRagdoll characterRagdoll;
    [SerializeField] private CharacterIK characterIK;
    private PlayerMovement playerMovement;




    void Start()
    {
        state = State.Alive;

        playerMovement = FindObjectOfType<PlayerMovement>();
        characterIK.ConfigureIK(playerMovement.GetEnemyTarget());
    }


    public void TakeDamage()
    {
        if (state == State.Dead)
            return;

        Die();
    }


    private void Die()
    {
        state = State.Dead;

        characterRagdoll.Ragdollify();
    }


    public void ShootAtPlayer()
    {
        if (state == State.Dead)
            return;

        enemyShooter.TryShooing();
    }


    public bool isDead()
    {
        return state == State.Dead;
    }
}
