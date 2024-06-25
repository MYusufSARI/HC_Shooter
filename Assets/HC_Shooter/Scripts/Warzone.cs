using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Warzone : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField]
    private SplineContainer playerSpline;




    public Spline GetPlayerSpline()
    {
        return playerSpline.Spline;
    }
}
