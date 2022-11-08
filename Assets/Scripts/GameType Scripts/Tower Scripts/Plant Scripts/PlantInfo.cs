using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlantInfo")]

public class PlantInfo : ScriptableObject
{
    //inital stats for plants
    public float initialMaxHealth;
    public float initialHealth;

    public float growthRate;
}
