using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Tags.GetAll("life_plant").Count == 0)
        {
            SceneManager.LoadScene("Scenes/Lose Screen");
        }
    }
}
