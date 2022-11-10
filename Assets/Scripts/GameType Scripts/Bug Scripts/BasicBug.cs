using System;
using System.Collections.Generic;
using UnityEngine;

class BasicBug : Bug
{
    float speed;

    public override void Start()
    {
        base.Start();
        speed = ((BugInfo)gameTypeInfo).speed;
    }

    public override void FixedUpdate()
    {
        GameObject plant = findNearestPlant();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (plant == null)
        {
            rb.velocity = Vector2.zero;
        }
        else 
        {
            Vector2 direction = plant.transform.position - transform.position;
            rb.velocity = direction.normalized * speed;
        }

        base.FixedUpdate();
    }
    
}