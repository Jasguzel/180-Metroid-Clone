using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;


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
    private float deathLevel = -3f;
    private int setHealth = 99;
    private float jump = 7f;

    //I forgot what this does but is important for respawning
    public Vector3 respawnPos;

    public GameObject BulletPrefab;
    public GameObject FirePos;

    public float speed = 10f;
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
        BulletMovememt();
        
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
    //this is what makes the bullet spawn and fly in the direction the player is lookin
    private void BulletMovememt()
    {
        if (Input.GetKeyDown(KeyCode.E) && direction == Vector3.right)
        {
            //this creates the bullet by setting the bullet to newBullet
            GameObject newBullet = Instantiate(BulletPrefab, transform.position, Quaternion.Euler(0, 0, -90));
            //this line grabs the new variable newBullet and says hey which direction are you going? Make sure direction is public in bullet script
            newBullet.GetComponent<Bullet>().direction = Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.Q) && direction == Vector3.left)
        {
            GameObject newBullet = Instantiate(BulletPrefab, transform.position, Quaternion.Euler(0, 0, 90));
            newBullet.GetComponent<Bullet>().direction = Vector3.left;
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
    //This will allow the player to respawn and if touched a flag will respawn at last touched flag
    public void Respawn()
    {
        transform.position = respawnPos;
    }
    private void Death()
    {
        if (health <= 0)
        {
            Respawn();
            health = setHealth;
        }
        if (transform.position.y < deathLevel)
        {
            Respawn();
            health = setHealth;
        }
    }
    private void DamageTaken()
    {
        StartCoroutine(Blink());
    }
    //this will 
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EasyEnemy>())
        {
            health = health - 15;
            DamageTaken();
        }
        if (other.GetComponent<HardEnemy>())
        {
            health = health - 35;
            DamageTaken();
        }
        if (other.GetComponent<Bandage>())
        {
            setHealth = 199;
            health = setHealth;
        }
        if (other.GetComponent<JumpBoost>())
        {
            jump = jump +3;
        }
    }
    public IEnumerator Blink()
    {
        for (int index = 0; index < 6; index++)
        {
            if (index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            if (index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(.1f);
        }
        GetComponent<MeshRenderer>().enabled = true;
    }
}
