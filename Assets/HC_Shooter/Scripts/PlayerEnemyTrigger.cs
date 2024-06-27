using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyTrigger : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private LineRenderer shootingLine;


    [Header(" Settings ")]
    [SerializeField] private LayerMask enemiesMask;
    private bool canCheckForShootingEnemies;


    private void Awake()
    {
        PlayerMovement.onEnteredWarzone += EnteredWarzoneCallback;
        PlayerMovement.onExitedWarzone += ExitedWarzoneCallback;
    }


    private void OnDestroy()
    {
        PlayerMovement.onEnteredWarzone -= EnteredWarzoneCallback;
        PlayerMovement.onExitedWarzone -= ExitedWarzoneCallback;
    }


    private void Update()
    {
        if (canCheckForShootingEnemies)
            CheckForShootingEnemies();
    }


    private void EnteredWarzoneCallback()
    {
        canCheckForShootingEnemies = true;
    }


    private void ExitedWarzoneCallback()
    {
        canCheckForShootingEnemies = false;
    }


    private void CheckForShootingEnemies()
    {
        //World Space ray origin
        Vector3 rayOrigin = shootingLine.transform.TransformPoint(shootingLine.GetPosition(0));
        Vector3 worldSpaceSecondPoint = shootingLine.transform.TransformPoint(shootingLine.GetPosition(1));

        Vector3 rayDirection = (worldSpaceSecondPoint - rayOrigin).normalized;
        float maxDistance = Vector3.Distance(rayOrigin, worldSpaceSecondPoint);

        RaycastHit[] hits = Physics.RaycastAll(rayOrigin, rayDirection, maxDistance, enemiesMask);

        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].collider.name);
        }
    }
}
