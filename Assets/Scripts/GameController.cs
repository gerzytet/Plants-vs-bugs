using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static Difficulty difficulty = Difficulty.NORMAL;
    public List<PlantInfo> plantList = new List<PlantInfo>();
    public static GameController instance { get; private set; }
    
    void Awake()
    {
        instance = this;
    }
    void FixedUpdate()
    {
        if (Tags.GetAll("life_plant").Count == 0)
        {
            SceneManager.LoadScene("Scenes/Lose Screen");
        }
    }

    public PlantInfo plantInfoFromSeeds(Item item)
    {
        foreach (PlantInfo plantInfo in plantList)
        {
            if (plantInfo.seed == item)
            {
                return plantInfo;
            }
        }
        return null;
    }
}
