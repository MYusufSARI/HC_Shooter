using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBulletsContainer : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform bulletsParent;


    [Header(" Settings ")]
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;
    private int bulletsShot;



    private void Awake()
    {
        PlayerShooter.onShot += OnShotCallback;
    }


    private void OnDestroy()
    {
        PlayerShooter.onShot -= OnShotCallback;
    }


    private void OnShotCallback()
    {
        bulletsShot++;

        if (bulletsShot > bulletsParent.childCount)
        {
            bulletsShot = bulletsParent.childCount;
        }

        bulletsParent.GetChild(bulletsShot - 1).GetComponent<Image>().color = inactiveColor;
    }
}
