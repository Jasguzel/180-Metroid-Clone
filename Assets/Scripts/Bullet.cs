using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int BulletSpeed = 15;
    public Vector3 direction;
    public int bulletDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * BulletSpeed * Time.deltaTime;
    }
    
}
