using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public GameObject clock;
    public Color noonColor;
    public Color midnightColor;

    // Update is called once per frame
    void Update()
    {
        Clock component;
        try
        {
            component = clock.GetComponent<Clock>();
        }
        catch (UnassignedReferenceException)
        {
            return;
        }
        float hour = component.hours + component.minutes / 60;
        float noonDistance = Math.Abs(13 - hour);
        float intensity = Mathf.Lerp(0.6f, 0.2f, noonDistance / 12f);
        Color color = Color.Lerp(noonColor, midnightColor, noonDistance / 12f);
        var component1 = GetComponent<Light>();
        component1.intensity = intensity;
        component1.color = color;
    }
}
