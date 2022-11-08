using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameType : Taggable
{

    //GameTypeInfo is a ScriptableObject that will provide basic game stats for each GameType you create
    public GameTypeInfo gameTypeInfo;
    //The Gameobject that represents the created GameType
    public GameObject gameTypePrefab;
    //starting health
    public float health;

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
