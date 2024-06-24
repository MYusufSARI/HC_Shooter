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
        animator.Play(RUN);
    }
}
