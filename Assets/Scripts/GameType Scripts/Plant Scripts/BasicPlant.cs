using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasicPlant : Plant
{
    [SerializeField] GameObject projectilePrefab;
    bool canShoot = true;
    float nextShot;

    public override void Shoot()
    {
        nextShot = nextShot = Time.time + ((PlantInfo)gameTypeInfo).reload;
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        print(GetDamage());
        projectile.GetComponent<Projectile>().SetProjectileDamage(GetDamage());
        Destroy(projectile, 5);
    }

    private void FixedUpdate()
    {
        Grow();
        if (((PlantInfo)gameTypeInfo).reload == 0)
            return;
        if (Time.time >= nextShot)
        {
            Shoot();
        }
    }
}
