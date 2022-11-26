using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpot : MonoBehaviour
{
    public static PlantSpot instance;

    void Awake()
    {
        instance = this;
    }
}
