using Unity.VisualScripting;
using UnityEngine;

public class Dandelion : Plant
{
    [SerializeField] GameObject projectilePrefab;
    float nextShot;

    private void ShootAngle(float angle)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation, transform);
        projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
        Projectile component = projectile.GetComponent<Projectile>();
        component.damage = damage;
        projectile.GetComponent<Rigidbody2D>().mass = knockback;
        Destroy(projectile, 5);
    }

    public override void Shoot()
    {
        base.Shoot();
        nextShot = Time.time + ((PlantInfo)gameTypeInfo).reload;
        for (int angle = 0; angle < 360; angle += 23)
        {
            ShootAngle(angle);
        }
    }
    
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        if (Time.time >= nextShot && FindNearestBugInRange() != null)
        {
            Shoot();
        }
    }
}