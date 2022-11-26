using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Type / New Plant")]

public class PlantInfo : GameTypeInfo
{
    //initial stats for plants
    public int cost;
    public float reload;
    public float growthRate;
    public float maxGrowth;
    public Item seed;
    public GameObject plant;
    public bool buyable;
    public GameObject inventoryDisplay;
    public Sprite sprite;
    public float range;
    [Space]
    public float initialScalePercent;
    public float growthMaxHealth;
    public float growthMaxDamage;
    public string displayName = "";
    public string guideDescription = "";
}
