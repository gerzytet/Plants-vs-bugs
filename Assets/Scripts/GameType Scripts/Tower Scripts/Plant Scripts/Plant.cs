using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Plant : Tower
{

    public float initialScale;
    private float healthDif;
    private float damageDif;
    [SerializeField] private float maxHealth;
    [SerializeField] private float damage;
    [SerializeField] private float growth = 0f;

    public override void Start()
    {
        base.Start();
        var plantInfo = (PlantInfo)gameTypeInfo;
        maxHealth = plantInfo.initialMaxHealth;
        damage = plantInfo.initialDamage;
        initialScale = transform.localScale.x;
        healthDif = plantInfo.growthMaxHealth - plantInfo.initialMaxHealth;
        damageDif = plantInfo.growthMaxDamage - plantInfo.initialDamage;
    }
    public abstract void Shoot();
    public virtual void Grow()
    {
        var plantInfo = (PlantInfo)gameTypeInfo;
        if(growth < plantInfo.maxGrowth)
        {
            growth += plantInfo.growthRate;

            if (growth > plantInfo.maxGrowth)
                growth = plantInfo.maxGrowth;

            float growthPercent = growth / plantInfo.maxGrowth;
            maxHealth = plantInfo.initialMaxHealth + growthPercent * healthDif;
            damage = plantInfo.initialDamage + growthPercent * damageDif;
            transform.localScale = Vector3.one * (Mathf.Lerp(0.2f, 1f, growthPercent * initialScale));

        }
    }
}
