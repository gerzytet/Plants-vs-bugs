using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBug : MonoBehaviour
{
    public GameObject tutorialController;

    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void OnDestroy()
    {
        tutorialController.GetComponent<TutorialController>().Advance();
    }
}
