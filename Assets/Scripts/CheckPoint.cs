using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Frederick Southworth
 * 11/6/2025
 * This script will control the players checkpoint areas
 */

public class CheckPoint : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Will ask if player touched me
    //then grab the respawnPos form player script and makes it = to the new position the player will respawn in
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().respawnPos = transform.position;
        }
    }
}
