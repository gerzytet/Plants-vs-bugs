using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Plant : Taggable
{
    public float initialScale;
    [SerializeField] private float maxHealth;
    public float health;
    [SerializeField] private float growth = 0f;
    public PlantInfo plantInfo;
    [SerializeField] private float startGrowthAmount = 0;
    [SerializeField] private float growthRate = 0;

    public override void Start()
    {
        base.Start();
        maxHealth = plantInfo.initialMaxHealth;
        initialScale = transform.localScale.x;
        health = plantInfo.initialHealth;
        startGrowthAmount = maxHealth - health;
        growthRate = plantInfo.growthRate;
    }

    public virtual void Grow()
    {
        float growthAmount = Math.Min(growthRate, maxHealth - health);
        growthAmount = Math.Min(growthAmount, startGrowthAmount);
        startGrowthAmount -= growthAmount;
        health += growthAmount;
        
        float healthPercent = health / maxHealth;
        transform.localScale = Vector3.one * (Mathf.Lerp(0.2f, 1f, healthPercent * initialScale));
    }

    public virtual void FixedUpdate()
    {
        Grow();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
