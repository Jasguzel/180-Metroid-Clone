using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Jasmine Guzeldere
 * 11/12/2025
 * Handles Portal Functionality
 */
public class Portals : MonoBehaviour
{
    public Transform teleportPoint;

    public void OnTriggerEnter(Collider other)
    {
        //Sets the touched objects position to the teleport points position
        other.transform.position = teleportPoint.position;
    }
}
