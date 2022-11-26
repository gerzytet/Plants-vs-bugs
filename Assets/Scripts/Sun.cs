using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public Color noonColor;
    public Color midnightColor;

    public AudioSource dayMusic;
    public AudioSource nightMusic;
    public AudioSource tutorialMusic;
    public AudioSource bossMusic;

    // Update is called once per frame
    void Update()
    {
        Clock component = Clock.instance;
        float hour = component.hours + component.minutes / 60;
        float noonDistance = Math.Abs(13 - hour);
        float intensity = Mathf.Lerp(0.6f, 0.2f, noonDistance / 12f);
        Color color = Color.Lerp(noonColor, midnightColor, noonDistance / 12f);
        var component1 = GetComponent<Light>();
        component1.intensity = intensity;
        component1.color = color;
        
        if (TutorialController.instance != null && TutorialController.instance.gameObject.activeInHierarchy)
        {
            if (!tutorialMusic.isPlaying)
            {
                tutorialMusic.Play();
            }
        } else if (Tags.GetAll("boss").Count > 0)
        {
            dayMusic.Stop();
            nightMusic.Stop();
            tutorialMusic.Stop();
            if (!bossMusic.isPlaying)
            {
                bossMusic.Play();
            }
        }
        else if (component.IsDay() && !dayMusic.isPlaying) {
            dayMusic.Play();
            tutorialMusic.Stop();
            nightMusic.Stop();
        }
        else if (!component.IsDay() && !nightMusic.isPlaying) {
            dayMusic.Stop();
            tutorialMusic.Stop();
            nightMusic.Play();
        }
    }
}
