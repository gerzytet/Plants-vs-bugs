using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    public Plant plant;
    void Update()
    {
        float range = ((PlantInfo) plant.gameTypeInfo).range;
        transform.localScale = Vector2.one * (range == float.PositiveInfinity ? 0 : range);
    }
}
