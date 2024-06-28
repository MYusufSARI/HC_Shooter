using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Animator animator;

    private const string RUN = "Run";
    private const string IDLE = "Idle";





    public void PlayRunAnimator()
    {
        Play(RUN);
    }


    public void PlayIdleAnimation()
    {
        Play(IDLE);
    }


    public void Play(string animationName)
    {
       animator.Play(animationName);
    }
}
