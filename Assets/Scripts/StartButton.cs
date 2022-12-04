using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        if (LevelSelect.instance.selected.isTutorial)
        {
            GameController.difficulty = Difficulty.EASY;
        }
        LevelSelect.instance.selected.Load();
        MainMenuJukebox.instance.Die();
        Debug.Log(GameController.difficulty);
    }
}
