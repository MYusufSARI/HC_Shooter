using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerIK : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RigBuilder rigBuilder;


    [Header(" Constraints ")]
    [SerializeField] private TwoBoneIKConstraint[] twoBoneIKConstraints;
    [SerializeField] private MultiAimConstraint[] multiAimConstraints;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ConfigureIK(Transform ikTarget)
    {
        rigBuilder.enabled = true;

        foreach (TwoBoneIKConstraint twoBoneIKConstraint in twoBoneIKConstraints)
        {
            twoBoneIKConstraint.data.target = ikTarget;
        }

        foreach (MultiAimConstraint multiAimConstraint in multiAimConstraints)
        {
            WeightedTransformArray weightedTransforms = new WeightedTransformArray();
            weightedTransforms.Add(new WeightedTransform(ikTarget, 1));

            multiAimConstraint.data.sourceObjects = weightedTransforms;
        }

        rigBuilder.Build();
    }

    public void DisableIK()
    {
        rigBuilder.enabled = false;
    }
}
