using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager instance;


    [Header(" Settings ")]
    private Vector3 lastCheckPointPosition;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


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
