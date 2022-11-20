using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBug : MonoBehaviour
{
    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void OnDestroy()
    {
        TutorialController.instance.Advance();
    }
}
