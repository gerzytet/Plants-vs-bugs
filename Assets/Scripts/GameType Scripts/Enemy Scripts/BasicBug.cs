using System;
using System.Collections.Generic;
using UnityEngine;

class BasicBug : Taggable
{
    public static float SPEED = 4f;
    public static double MAX_HEALTH = 100;
    public double health = MAX_HEALTH;
    private GameObject findNearestPlant()
    {
        Vector2 myLocation = transform.position;
        GameObject closestPlant = null;
        float closestDistance = float.MaxValue;
        foreach (GameObject plant in Tags.GetAll("plant"))
        {
            float dist = Vector2.Distance(myLocation, plant.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestPlant = plant;
            }
        }
        return closestPlant;
    }
    
    private void Update()
    {
        GameObject plant = findNearestPlant();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }
        if (plant == null)
        {
            Debug.Log("no plant");
            rb.velocity = Vector2.zero;
        }
        else 
        {
            Vector2 direction = plant.transform.position - transform.position;
            rb.velocity = direction.normalized * SPEED;
        }
    }


    public void OnCollisionStay2D(Collision2D collision2D)
    {
        if (Tags.HasTag(collision2D.gameObject, "plant"))
        {
            collision2D.gameObject.GetComponent<Plant>().health -= 2;
        }
    }
}