using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Frederick Southworth, Jasmine Guzeldere
 * 10/30/2025
 * This script will control all player behaviors and movement
 */

public class PlayerController : MonoBehaviour
{
    //This part of the code will have all Public and Private variables
    private Vector3 direction;
    private Rigidbody rb;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    
    
    private void PlayerMovement()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
    }

}
