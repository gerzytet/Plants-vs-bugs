using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Plant : Tower
{
    [SerializeField] Transform plantTransform;
    public float initialScale;
    private float healthDif;
    private float damageDif;
    [SerializeField] private float maxHealth;
    [SerializeField] private float damage;
    [SerializeField] private float growth = 0f;

    private void Start()
    {
        maxHealth = ((PlantInfo)gameTypeInfo).initialMaxHealth;
        damage = ((PlantInfo)gameTypeInfo).initialDamage;
        initialScale = transform.localScale.x;
        healthDif = ((PlantInfo)gameTypeInfo).growthMaxHealth - ((PlantInfo)gameTypeInfo).initialMaxHealth;
        damageDif = ((PlantInfo)gameTypeInfo).growthMaxDamage - ((PlantInfo)gameTypeInfo).initialDamage;
    }
    public abstract void Shoot();
    public virtual void Grow()
    {
        if(growth < ((PlantInfo)gameTypeInfo).maxGrowth)
        {
            growth += ((PlantInfo)gameTypeInfo).growthRate;

            if (growth > ((PlantInfo)gameTypeInfo).maxGrowth)
                growth = ((PlantInfo)gameTypeInfo).maxGrowth;

            float growthPercent = growth / ((PlantInfo)gameTypeInfo).maxGrowth;
            maxHealth = ((PlantInfo)gameTypeInfo).initialMaxHealth + growthPercent * healthDif;
            damage = ((PlantInfo)gameTypeInfo).initialDamage + growthPercent * damageDif;
            plantTransform.localScale = Vector3.one * (Mathf.Lerp(0.2f, 1f, growthPercent * initialScale));

        }
    }
}
