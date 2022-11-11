using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    public void StartGameEasy()
    {
        StartGame();
        GameController.difficulty = Difficulty.EASY;
    }

    public void StartGameNormal()
    {
        StartGame();
        GameController.difficulty = Difficulty.NORMAL;
    }
    
    public void StartGameHard()
    {
        StartGame();
        GameController.difficulty = Difficulty.HARD;
    }
}
