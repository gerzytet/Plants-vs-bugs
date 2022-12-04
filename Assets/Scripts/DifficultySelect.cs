using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelect : MonoBehaviour
{
    
    public static DifficultySelect instance;
    void Start()
    {
        GetComponent<TMP_Dropdown>().value = 1;
        GameController.difficulty = Difficulty.NORMAL;
    }

    void Awake()
    {
        instance = this;
    }

    public void difficultyChanged()
    {
        Debug.Log(GetComponent<TMP_Dropdown>().value);
        switch (GetComponent<TMP_Dropdown>().value)
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
