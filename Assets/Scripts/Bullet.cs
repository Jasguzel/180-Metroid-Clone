using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/*
 * Frederick Southworth
 * 11/12/2025
 * This script will control the bullet's behavior
 */

public class Bullet : MonoBehaviour
{
    public int BulletSpeed = 15;
    public Vector3 direction;
    public int bulletDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform.position += direction * BulletSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * BulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
