using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sunflower : Plant
{
    [SerializeField] GameObject projectilePrefab;
    float nextShot;

    public override void Shoot()
    {
        nextShot = Time.time + ((PlantInfo)gameTypeInfo).reload;
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation, transform);
        projectile.transform.rotation = Quaternion.Euler(0, 0,
            Random.Range(-10, 10) + Vector2.SignedAngle(Vector2.right,
                FindNearestBugInRange().transform.position - transform.position));
        projectile.GetComponent<Projectile>().SetProjectileDamage(GetDamage());
        Destroy(projectile, 5);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        if (((PlantInfo)gameTypeInfo).reload == 0)
            return;
        if (Time.time >= nextShot && FindNearestBugInRange() != null)
        {
            Shoot();
        }
    }
}
