using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpot : MonoBehaviour
{
    public GameObject obj;

    public void Spawn()
    {
        Instantiate(obj, transform.position, transform.rotation);
    }
}
