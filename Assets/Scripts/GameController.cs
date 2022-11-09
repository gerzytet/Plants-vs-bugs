using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public List<PlantInfo> plantList = new List<PlantInfo>();
    // Update is called once per frame
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
