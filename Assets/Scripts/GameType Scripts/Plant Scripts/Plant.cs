using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Plant : GameType
{

    public float initialScale;
    [SerializeField] private float maxHealth;
    [SerializeField] private float growth = 0f;
    [SerializeField] private float startGrowthAmount = 0;
    [SerializeField] private float growthRate = 0;

    public override void Start()
    {
        base.Start();
        maxHealth = ((PlantInfo)(gameTypeInfo)).initialMaxHealth;
        initialScale = transform.localScale.x;
        health = ((PlantInfo)(gameTypeInfo)).initialHealth;
        startGrowthAmount = maxHealth - health;
        growthRate = ((PlantInfo)(gameTypeInfo)).growthRate;
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
}
