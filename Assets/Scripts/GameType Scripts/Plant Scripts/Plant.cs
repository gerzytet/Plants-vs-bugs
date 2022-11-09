using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Plant : GameType
{
    private float initialMaxHealth;
    private float initialDamage;
    private float healthDif;
    private float damageDif;
    private float scaleDif;
    [SerializeField] Transform plantTransform;
    [SerializeField] float scale;
    [SerializeField] float maxHealth;
    [SerializeField] private float growth = 0f;



    private void Start()
    {
        AddTag();
        initialMaxHealth = gameTypeInfo.maxHealth;
        initialDamage = gameTypeInfo.damage;
        scale = ((PlantInfo)gameTypeInfo).initialScalePercent;
        healthDif = ((PlantInfo)gameTypeInfo).growthMaxHealth - initialMaxHealth;
        damageDif = ((PlantInfo)gameTypeInfo).growthMaxDamage - initialDamage;
        scaleDif = 1 - ((PlantInfo)gameTypeInfo).initialScalePercent;
    }
    public abstract void Shoot();
    public virtual void Grow()
    {
        if (growth < ((PlantInfo)gameTypeInfo).maxGrowth)
        {
            growth += ((PlantInfo)gameTypeInfo).growthRate;

            if (growth > ((PlantInfo)gameTypeInfo).maxGrowth)
                growth = ((PlantInfo)gameTypeInfo).maxGrowth;

            float growthPercent = growth / ((PlantInfo)gameTypeInfo).maxGrowth;
            maxHealth = initialMaxHealth + growthPercent * healthDif;
            SetDamage(initialDamage + growthPercent * damageDif);
            plantTransform.localScale = Vector3.one * (scale + scaleDif * growthPercent);

        }
    }
}