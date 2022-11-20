using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovementTest : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        TutorialController.instance.GetComponent<TutorialController>().Advance();
        Destroy(gameObject);
    }
}
