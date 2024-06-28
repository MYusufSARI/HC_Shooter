using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerDetection : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private float detectionRadius;

    private PlayerMovement playerMovement;



    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        if (GameManager.instance.IsGameState())
        {
            DetectStuff();
        }
    }


    private void DetectStuff()
    {
        Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider collider in detectedObjects)
        {
            if (collider.CompareTag("WarzoneEnter"))
            {
                EnteredWarzoneCallback(collider);
            }

            else if (collider.CompareTag("Finish"))
            {
                HitFinishLine();
            }
        }
    }


    private void EnteredWarzoneCallback(Collider warzoneTriggerCollider)
    {
        Warzone warzone = warzoneTriggerCollider.GetComponentInParent<Warzone>();
        playerMovement.EnteredWarzoneCallback(warzone);
    }


    private void HitFinishLine()
    {
        Debug.Log("Hit finish line");
        playerMovement.HitFinishLine();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
