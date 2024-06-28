using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [Header(" Settings ")]
    private Vector3 lastCheckPointPosition;


    private void Awake()
    {
        DontDestroyOnLoad(this);

        CheckPoint.onInteracted += CheckPointInteractedCallback;
    }


    private void OnDestroy()
    {
        CheckPoint.onInteracted -= CheckPointInteractedCallback;
    }


    private void CheckPointInteractedCallback(CheckPoint checkPoint)
    {
        lastCheckPointPosition = checkPoint.GetPosition();
    }
}
