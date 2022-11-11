using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovementTest : MonoBehaviour
{
    public GameObject tutorialController;
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        tutorialController.GetComponent<TutorialController>().Advance();
        Destroy(gameObject);
    }
}
