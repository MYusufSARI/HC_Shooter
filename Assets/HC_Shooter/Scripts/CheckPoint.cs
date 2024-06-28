using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private SpriteRenderer gradient;




    public void Interact()
    {
        gradient.color = Color.green;
    }
}
