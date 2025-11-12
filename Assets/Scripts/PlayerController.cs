using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    //I forgot what this does but is important for respawning
    public Vector3 respawnPos;

    private float DeathLevel = -3f;
    public float speed = 10f;
    public float jump = 7f;
    public float fall = 7f;
    public int fallAmount = 1;
    public float floorCheckDist = 1.1f;
    public int health = 99;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();
        Death();
    }

    
    /// <summary>
    /// This will let the player move left and right in the levels
    /// </summary>
    private void PlayerMovement()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);


            //Rotates the object from its current rotation value by the new amount
            //Quaternion rotationalAngle = Quaternion.Euler(0f, 180f, 0f);

            //sets the rotation value to a fixed value
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }
    }
    /// <summary>
    /// this will allow the player to jump up and if they want go down quicker
    /// </summary>
    private void PlayerJump()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && IsGrounded())
        {
            //AddForce is for jumping and using earth gravity, can ajust gravity... Impulse give it the tappy state
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
        else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && fallAmount > 0)
        {
            //This is to force the player down if they are in air and want to go down but cant spam infinetly
            rb.AddForce(Vector3.down * fall, ForceMode.Impulse);

            fallAmount--;
        }
    }
    private bool IsGrounded()
    {
        bool isGrounded = false;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, floorCheckDist))
        {
            isGrounded = true;
            fallAmount = 1;
        }
        return isGrounded;
    }
    public void Respawn()
    {
        transform.position = respawnPos;
    }
    private void Death()
    {
        if (health <= 0)
        {
            Respawn();
        }
        if (transform.position.y < DeathLevel)
        {
            Respawn();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EasyEnemy>())
        {
            other.GetComponent<PlayerController>().health-- 15;
        }
    }
}
