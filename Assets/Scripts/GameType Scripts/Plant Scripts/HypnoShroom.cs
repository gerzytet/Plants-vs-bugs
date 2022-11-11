
using System;
using Unity.VisualScripting;
using UnityEngine;

public class HypnoShroom : Plant
{
    public override void Shoot()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Tags.HasTag(collision.gameObject, "bug"))
        {
            Die();
            collision.gameObject.GetComponent<Bug>().Hypnotize();
        }
    }
}
