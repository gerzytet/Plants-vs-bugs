using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 4.5f;
    public float damage;
    public Rigidbody2D rb;

    public void SetProjectileDamage(float _damage)
    {
        damage = _damage;
    }
    private void Start()
    {
        rb.velocity = transform.right * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Tags.HasTag(collision.gameObject, "bug"))
        {
            print("did it");
            collision.gameObject.GetComponent<GameType>().Damage(damage);
            Destroy(gameObject);
        }
    }



}
