using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasicPlant : Plant
{
    [SerializeField] Projectile projectilePrefab;
    bool canShoot = true;
    float nextShot;

    public override void Shoot()
    {
        /*
        nextShot = nextShot = Time.time + ((PlantInfo)gameTypeInfo).reload;
        Projectile projectile = Instantiate(projectilePrefab, transform.position, transform.rotation, transform);
        Destroy(projectile, 5);
        */
    }

    private void FixedUpdate()
    {
        Grow();
        if (Time.time >= nextShot)
        {
            Shoot();
        }
    }
}
