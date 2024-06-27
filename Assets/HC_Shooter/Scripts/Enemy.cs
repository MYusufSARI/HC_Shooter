using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum State
    {
        Alive,
        Dead,
    }

    private State state;

    [Header(" Elements ")]
    [SerializeField] private CharacterRagdoll characterRagdoll;



    private void Start()
    {
        state = State.Alive;
    }


    public void TakeDamage()
    {
        if (state == State.Dead)
        {
            return;
        }

        else
        {
            Die();
        }
    }


    private void Die()
    {
        state = State.Dead;

        characterRagdoll.Ragdollify();
    }
}