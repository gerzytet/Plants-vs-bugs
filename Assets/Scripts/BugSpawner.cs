using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    private Dictionary<int, Dictionary<int, List<BugInfo>>> spawnSchedule = new Dictionary<int, Dictionary<int, List<BugInfo>>>();
    public List<Dictionary<BugInfo, int>> waves;
    public BugInfo basicBug;

    public GameObject clock;

    private int randomSpawnHour()
    {
        return Random.Range(20, 26) % 24;
    }

    public void Awake()
    {
        waves = new List<Dictionary<BugInfo, int>>
        {
            new Dictionary<BugInfo, int>(),
            new Dictionary<BugInfo, int> {
                {basicBug, 5}
            },
            new Dictionary<BugInfo, int> {
                {basicBug, 10}
            },
            new Dictionary<BugInfo, int> {
                {basicBug, 15}
            }
        };

        for (int i = 0; i < waves.Count; i++)
        {
            var wave = waves[i];
            if (!spawnSchedule.ContainsKey(i))
            {
                spawnSchedule[i] = new Dictionary<int, List<BugInfo>>();
            }
            var schedule = spawnSchedule[i];
            foreach (var bug in wave)
            {
                var bugInfo = bug.Key;
                var bugCount = bug.Value;
                for (int j = 0; j < bugCount; j++)
                {
                    var hour = randomSpawnHour();
                    if (!schedule.ContainsKey(hour))
                    {
                        schedule[hour] = new List<BugInfo>();
                    }
                    schedule[hour].Add(bugInfo);
                }
            }
        }
    }
    void SpawnBugAt(Vector2 location, GameObject bug)
    {
        Instantiate(bug, location, Quaternion.identity);
    }
    
    void FixedUpdate()
    {
        var clockComponent = clock.GetComponent<Clock>();
        if (spawnSchedule.ContainsKey(clockComponent.day) && spawnSchedule[clockComponent.day].ContainsKey(clockComponent.hours))
        {
            var bugs = spawnSchedule[clockComponent.day][clockComponent.hours];
            foreach (var bug in bugs)
            {
                List<GameObject> spawnPoints = Tags.GetAll("bug_spawn");
                var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                SpawnBugAt(spawnPoint.transform.position, bug.bug);
            }
            spawnSchedule[clockComponent.day].Remove(clockComponent.hours);
        }
    }
}
