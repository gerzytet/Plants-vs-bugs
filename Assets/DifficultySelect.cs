using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelect : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMP_Dropdown>().value = 1;
        GameController.difficulty = Difficulty.NORMAL;
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
