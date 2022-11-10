using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bug : GameType
{
    public GameObject player;
    public virtual void Update()
    {
        GameObject spriteObject = transform.GetChild(1).gameObject;
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        spriteObject.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, velocity));
    }
    
    protected GameObject findNearestPlant()
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
    
    public void OnCollisionStay2D(Collision2D collision2D)
    {
        if (Tags.HasTag(collision2D.gameObject, "plant"))
        {
            collision2D.gameObject.GetComponent<GameType>().Damage(gameTypeInfo.damage);
        }
    }

    public override void Die()
    {
        base.Die();
        MainCharacter.instance.money += ((BugInfo)gameTypeInfo).moneyOnDeath;
    }
}
