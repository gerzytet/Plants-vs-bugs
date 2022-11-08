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

    private void Awake()
    {
        health = gameTypeInfo.maxHealth;
    }

    public virtual float GetHealth()
    {
        return health;
    }


    public virtual void SetHeatlh(float _health)
    {
        health = _health;
    }
    public virtual void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    public virtual void Heal(float heal, float maxHealth)
    {
        health += heal;
        if (health >= maxHealth)
            health = maxHealth;
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);

    }
}
