using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlant : Plant
{

    bool canShoot = true;

    float nextShot;

    private void Awake()
    {
        
    }

    public override void Shoot()
    {
        Debug.Log("shoot");
        nextShot = nextShot = Time.time + ((PlantInfo)gameTypeInfo).reload;
        //shoot script
    }

    public override void Grow()
    {
        base.Grow();
    }

    private void FixedUpdate()
    {
        Grow();
        if(Time.time >= nextShot)
        {
            Shoot();
        }
    }
}
