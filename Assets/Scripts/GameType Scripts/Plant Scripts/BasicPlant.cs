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
            // transform.LookAt(FindNearestBug().transform);
            nextShot = nextShot = Time.time + ((PlantInfo)gameTypeInfo).reload;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            projectile.GetComponent<Projectile>().SetProjectileDamage(GetDamage());
            Destroy(projectile, 5);
    }

    private GameObject FindNearestBug()
    {
        Vector2 myLocation = transform.position;
        GameObject closestBug = null;
        float closestDistance = float.MaxValue;
        foreach (GameObject bug in Tags.GetAll("bug"))
        {
            float dist = Vector2.Distance(myLocation, bug.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestBug = bug;
            }
        }
        return closestBug;
    }

    private void FixedUpdate()
    {
        Grow();
        if (((PlantInfo)gameTypeInfo).reload == 0)
            return;
        if (Time.time >= nextShot && FindNearestBug() != null)
        {
            Shoot();
        }
    }
}
