using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Warzone : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField]
    private SplineContainer playerSpline;


    [Header(" Settings ")]
    [SerializeField]
    private float duration;

    [SerializeField]
    private string animationToPlay;





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
}
