using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public float speed;
    public GameObject explosion;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);//moves the projectile forward
        Destroy(gameObject, 3);// destroys projectile in 3 seconds
    }

    private void OnTriggerEnter(Collider other)
    {
        //destroys projectile when it hits the enemy
        if (other.gameObject.CompareTag("Wall"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
