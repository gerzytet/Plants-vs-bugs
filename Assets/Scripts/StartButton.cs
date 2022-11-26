using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        LevelSelect.instance.selected.Load();
        MainMenuJukebox.instance.Die();
    }
    
    public void difficultyChanged(int value)
    {
        switch (value)
        {
            case 0:
                GameController.difficulty = Difficulty.EASY;
                break;
            case 1:
                GameController.difficulty = Difficulty.NORMAL;
                break;
            case 2:
                GameController.difficulty = Difficulty.HARD;
                break;
        }
    }
}
