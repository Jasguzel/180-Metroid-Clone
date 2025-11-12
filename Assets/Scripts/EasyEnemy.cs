using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Frederick Southworth
 * 11/6/2025
 * This script will control the easy enemy's behavior
 */
public class EasyEnemy : MonoBehaviour
{
    public int EasyHealth = 1;
    public Transform leftPoint;
    public Transform rightPoint;
    public float speed = 10;
    private Vector3 direction;
    private Vector3 startLeftPos;
    private Vector3 startRightPos;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.left;
        startLeftPos = leftPoint.position;
        startRightPos = rightPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
        //this will ask if the player is going left and is at the left position boundary
        if (direction == Vector3.left && transform.position.x <= startLeftPos.x)
        {
            direction = Vector3.right;
        }
        //this will ask if the player is going right and is at the right position boundary
        else if (direction == Vector3.right && transform.position.x >= startRightPos.x)
        {
            direction = Vector3.left;
        }
    }//MUST MAKE SURE THE LEFT AND RIGHT HAVE DIFFERENT GREATER/LESS THAN SYMBOLS
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            EasyHealth--;
            if(EasyHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
