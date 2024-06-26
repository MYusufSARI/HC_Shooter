using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerIK : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField]
    private RigBuilder rigBuilder;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ConfigureIK(Transform ikTarger)
    {
        rigBuilder.enabled = true;
    }

    public void DisableIK()
    {
        rigBuilder.enabled = false;
    }
}
