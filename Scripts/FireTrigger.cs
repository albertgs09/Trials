using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    public bool IsFiring;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;
    public FireProjectile fire;
    // Update is called once per frame
    void Update()
    {  
            if (Input.GetButtonDown("Fire1"))//gets input from mouse
            {
                IsFiring = true;
            }
            else
            {
                IsFiring = false;
            }
       
        if (IsFiring)
        {

            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                FireProjectile newProjectile = Instantiate(fire, firePoint.position, firePoint.rotation) as FireProjectile;
                newProjectile.speed = bulletSpeed;
            }

        }
        else
        {
            shotCounter = 0;
        }
    }
}
