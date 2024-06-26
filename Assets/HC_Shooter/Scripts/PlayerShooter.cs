using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject shootingLine;




    private void Awake()
    {
        PlayerMovement.onEnteredWarzone += EnteredWarzoneCallback;
    }


    private void OnDestroy()
    {
        PlayerMovement.onEnteredWarzone -= EnteredWarzoneCallback;
    }


    private void Start()
    {
        SetShootingLineVisibility(false);
    }


    private void EnteredWarzoneCallback()
    {
        SetShootingLineVisibility(true);
    }


    private void SetShootingLineVisibility(bool visibility)
    {
        shootingLine.SetActive(visibility);
    }
}
