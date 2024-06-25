using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField]
    private Animator animator;

    private const string RUN = "Run";




    public void PlayRunAnimator()
    {
        Play(RUN);
    }


    public void Play(string animationName)
    {
        animator.Play(animationName);
    }


    public void Play(string animationName, float animatorSpeed)
    {
        animator.speed = animatorSpeed;
        Play(animationName);
    }
}
