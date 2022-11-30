using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    private Dictionary<int, Dictionary<int, List<BugInfo>>> spawnSchedule = new Dictionary<int, Dictionary<int, List<BugInfo>>>();
    public List<Dictionary<BugInfo, int>> waves;
    public List<int> waveMoney;
    private List<int> waveBugCounts = new();
    private float roundedOutMoney = 0;
    
    public BugInfo basicBug;
    public BugInfo mamaBug;
    public BugInfo tinyBug;
    public BugInfo bossBug;
    public BugInfo stinkBug;
    public static BugSpawner instance { get; private set; }

    private int randomSpawnHour()
    {
        return Random.Range(21, 27) % 24;
    }

    public void Awake()
    {
        instance = this;
        waves = new List<Dictionary<BugInfo, int>>
        {
            new() {
                {tinyBug, 5},
                {basicBug, 2}
            },
            new() {
                {basicBug, 8}
            },
            new() {
                {tinyBug, 30},
                {stinkBug, 2}
            },
            new() {
                {basicBug, 10},
                {mamaBug, 2},
                {stinkBug, 4}
            },
            new ()
            {
                {mamaBug, 11}
            },
            new()
            {
                {bossBug, 1}
            }
        };
        
        spawnSchedule = new Dictionary<int, Dictionary<int, List<BugInfo>>>();
        for (int i = 0; i < waves.Count; i++)
        {
            int day = i + 1;
            var wave = waves[i];
            if (!spawnSchedule.ContainsKey(day))
            {
                spawnSchedule[day] = new Dictionary<int, List<BugInfo>>();
            }
            var schedule = spawnSchedule[day];
            int totalBugCount = 0;
            foreach (var bug in wave)
            {
                var bugInfo = bug.Key;
                int bugCount = bug.Value;
                if (bugInfo != bossBug)
                {
                    bugCount = (int) (bugCount * GameController.difficulty.BugMultiplier());
                }
                totalBugCount += bugCount;
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
            waveBugCounts.Add(totalBugCount);
        }
    }
    void SpawnBugAt(Vector2 location, GameObject bug, int money)
    {
        GameObject newBug = Instantiate(bug, location, Quaternion.identity);
        newBug.GetComponent<Bug>().moneyOnDeath = money;
    }
    
    void FixedUpdate()
    {
        var clockComponent = Clock.instance;
        if (spawnSchedule.ContainsKey(clockComponent.day) && spawnSchedule[clockComponent.day].ContainsKey(clockComponent.hours))
        {
            var bugs = spawnSchedule[clockComponent.day][clockComponent.hours];
            foreach (var bug in bugs)
            {
                List<GameObject> spawnPoints = Tags.GetAll("bug_spawn");
                var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                float moneyPerBug = waveMoney[clockComponent.day - 1] / (float) waveBugCounts[clockComponent.day - 1];
                roundedOutMoney += moneyPerBug - (int) moneyPerBug;
                int money = (int) moneyPerBug;
                if (roundedOutMoney >= 0.999)
                {
                    money += 1;
                    roundedOutMoney -= 1;
                }
                SpawnBugAt(spawnPoint.transform.position, bug.bug, money);
            }
            spawnSchedule[clockComponent.day].Remove(clockComponent.hours);
        }
    }
}
