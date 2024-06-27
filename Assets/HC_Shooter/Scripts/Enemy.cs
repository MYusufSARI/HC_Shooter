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
    [SerializeField] private CharacterRagdoll characterRagdoll;
    [SerializeField] private CharacterIK characterIK;
    private Transform playerTransform;



    void Start()
    {
        state = State.Alive;

        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        characterIK.ConfigureIK(playerTransform);
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
        Debug.Log("Shooting at Player");
    }
}
