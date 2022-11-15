using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    public Plant plant;
    void Update()
    {
        transform.localScale = Vector2.one * ((PlantInfo) plant.gameTypeInfo).range;
    }
}
