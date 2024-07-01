using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Dreamteck.Splines;

public class Warzone : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform ikTarget;
    [SerializeField] private SplineComputer newPlayerSpline;
    [SerializeField] private SplineFollower ikSplineFollower;


    [Header(" Settings ")]
    [SerializeField] private float duration;
    [SerializeField] private string animationToPlay;


    [Header(" Next Warzone ")]
    [SerializeField] private Warzone nextWarzone;



    private void Start()
    {
        ikSplineFollower.followDuration = duration;
    }


    public void StartAnimatingIKTarget()
    {
        ikSplineFollower.follow = true;
    }


    public SplineComputer GetPlayerSpline()
    {
        return newPlayerSpline;
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


    public Warzone GetNextWarzone()
    {
        return nextWarzone;
    }
}
