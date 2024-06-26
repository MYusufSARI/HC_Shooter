using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject shootingLine;
    [SerializeField] private Transform bulletSpawnPosition;


    [Header(" Settings ")]
    private bool canShoot;




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


    private void Start()
    {
        SetShootingLineVisibility(false);
    }


    private void Update()
    {
        if (canShoot)
        {
            ManageShooting();
        }
    }


    private void ManageShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.identity);
    }


    private void EnteredWarzoneCallback()
    {
        SetShootingLineVisibility(true);
        canShoot = true;
    }


    private void ExitedWarzoneCallback()
    {
        SetShootingLineVisibility(false);
        canShoot = false;
    }


    private void SetShootingLineVisibility(bool visibility)
    {
        shootingLine.SetActive(visibility);
    }
}
