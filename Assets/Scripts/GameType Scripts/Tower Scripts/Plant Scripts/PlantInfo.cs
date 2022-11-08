using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameType/Tower/New Plant")]

public class PlantInfo : GameTypeInfo
{
    //basic stats for plants
    public int cost;
    public float initialMaxHealth;
    public float initialDamage;
    public float reload;

    public float growthRate;
    public float maxGrowth;
    public float growthMaxHealth;
    public float growthMaxDamage;
}
