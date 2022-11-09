using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 4.5f;
    public float damage;

    private void Start()
    {
        damage = gameObject.GetComponentInParent<GameType>().GetDamage();
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Tags.HasTag(collision.gameObject, "bug"))
        {
            collision.gameObject.GetComponent<GameType>().Damage(damage);
        }
        Destroy(gameObject);
    }
}
