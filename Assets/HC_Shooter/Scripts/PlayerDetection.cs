using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{

    [Header(" Settings ")]
    [SerializeField]
    private float detectionRadius;

    private void Update()
    {
        DetectStuff();
    }


    private void DetectStuff()
    {
        Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider collider in detectedObjects)
        {
            Debug.Log(collider.name);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
