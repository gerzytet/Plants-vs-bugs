using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject basicBug;
    public float spawnChancePerTick;

    public GameObject clock;
    void SpawnBugAt(Vector2 location)
    {
        Instantiate(basicBug, location, Quaternion.identity);
    }
    
    void FixedUpdate()
    {
        if (Random.Range(0f, 1f) < spawnChancePerTick && !clock.GetComponent<Clock>().IsDay())
        {
            List<GameObject> bugSpawns = Tags.GetAll("bug_spawn");
            Debug.Log(bugSpawns.Count);
            GameObject spawn = bugSpawns[Random.Range(0, bugSpawns.Count)];
            SpawnBugAt(spawn.transform.position);
        }
    }
}
