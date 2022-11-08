using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Type / New Plant")]

public class PlantInfo : GameTypeInfo
{
    //inital stats for plants
    public float initialMaxHealth;
    public float initialHealth;

    public float growthRate;
}
