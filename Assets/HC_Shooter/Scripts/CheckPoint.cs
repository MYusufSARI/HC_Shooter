using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private SpriteRenderer gradient;

    [Header(" Actions ")]
    public static Action<CheckPoint> onInteracted;


    public void Interact()
    {
        gradient.color = Color.green;

        onInteracted?.Invoke(this);
    }


    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
