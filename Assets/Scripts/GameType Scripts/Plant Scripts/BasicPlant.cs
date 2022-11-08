using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasicPlant : Plant
{
    [SerializeField] GameObject projectile;
    bool canShoot = true;
    float nextShot;

    public override void Shoot()
    {
        nextShot = nextShot = Time.time + ((PlantInfo)gameTypeInfo).reload;
        
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
