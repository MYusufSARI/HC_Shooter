using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Warzone : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private SplineContainer playerSpline;
    [SerializeField] private Transform ikTarget;
    [SerializeField] private SplineAnimate ikSplineAnimate;


    [Header(" Settings ")]
    [SerializeField] private float duration;
    [SerializeField] private string animationToPlay;



    private void Start()
    {
        ikSplineAnimate.Duration = duration;
    }


    public void StartAnimatingIKTarget()
    {
        ikSplineAnimate.Play();
    }

    public Spline GetPlayerSpline()
    {
        return playerSpline.Spline;
    }


    public float GetDuration()
    {
        return duration;
    }

    public string GetAnimationToPlay()
    {
        return animationToPlay;
    }

    public Transform GetIKTarget()
    {
        return ikTarget;
    }
}
