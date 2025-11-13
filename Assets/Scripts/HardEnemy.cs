using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Frederick Southworth
 * 11/6/2025
 * This script will control the easy enemy's behavior
 */
public class HardEnemy : MonoBehaviour
{
    public int HardHealth = 10;
    public float speed = 5;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HardMovement();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            HardHealth -= other.GetComponent<Bullet>().bulletDamage;
        }
        if (HardHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void HardMovement()
    {
        RaycastHit hit;
        Vector3 leftOrigin;
        Vector3 rightOrigin;

        leftOrigin = transform.position + new Vector3(0, 0, 0);
        rightOrigin = transform.position + new Vector3(0, 0, 0);

        if (Physics.Raycast(leftOrigin, Vector3.left, out hit, 15))
        {
            transform.position += direction * speed * Time.deltaTime;
            if (hit.transform.GetComponent<PlayerController>())
            {
                direction = Vector3.left;
            }
        }
            if (Physics.Raycast(rightOrigin, Vector3.right, out hit, 15))
            {
                transform.position += direction * speed * Time.deltaTime;
                if (hit.transform.GetComponent<PlayerController>())
                {
                    direction = Vector3.right;
                }
            }
    }
    private void Spinning()
    {
        
    }
}