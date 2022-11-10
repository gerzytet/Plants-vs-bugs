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
    private float range;
    [SerializeField] float healTime = 1f;
    [SerializeField] float healPercent = .02f;
    float nextHealTime;
    [SerializeField] Transform plantTransform;
    [SerializeField] float scale;
    [SerializeField] float maxHealth;
    [SerializeField] private float growth = 0f;
    
    public override void Start()
    {
        base.Start();
        maxHealth = gameTypeInfo.maxHealth;
        initialMaxHealth = gameTypeInfo.maxHealth;
        initialDamage = gameTypeInfo.damage;
        scale = ((PlantInfo)gameTypeInfo).initialScalePercent;
        healthDif = ((PlantInfo)gameTypeInfo).growthMaxHealth - initialMaxHealth;
        damageDif = ((PlantInfo)gameTypeInfo).growthMaxDamage - initialDamage;
        scaleDif = 1 - ((PlantInfo)gameTypeInfo).initialScalePercent;
        range = ((PlantInfo)gameTypeInfo).range;
    }
    public virtual void FixedUpdate()
    {
        Grow();
        if(nextHealTime <= Time.time)
        {
            Heal(maxHealth * healPercent, maxHealth);
            nextHealTime = Time.time + healTime;
        }
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
    public virtual GameObject FindNearestBugInRange()
    {
        Vector2 myLocation = transform.position;
        GameObject closestBug = null;
        float closestDistance = float.MaxValue;
        foreach (GameObject bug in Tags.GetAll("bug"))
        {
            float dist = Vector2.Distance(myLocation, bug.transform.position);
            if (dist < closestDistance && dist < range)
            {
                closestDistance = dist;
                closestBug = bug;
            }
        }
        return closestBug;
    }


}