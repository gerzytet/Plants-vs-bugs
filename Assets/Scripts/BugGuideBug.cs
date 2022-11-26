using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugGuideBug : MonoBehaviour
{
    private BugInfo info;
    private bool overlapping = false;

    void Start()
    {
        info = (BugInfo) GetComponent<Bug>().gameTypeInfo;
        SetLights(false);
    }

    private void SetLights(bool active)
    {
        foreach (Light light in GetComponentsInChildren<Light>(true))
        {
            light.gameObject.SetActive(active);
        }
    }
    
    void Update()
    {
        Vector2 pointerLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (overlapping != GetComponentInChildren<Collider2D>().OverlapPoint(pointerLocation))
        {
            overlapping = !overlapping;
            if (overlapping)
            {
                GuideText.instance.SetText(info.displayName + ":\n" + info.guideDescription);
                SetLights(true);
            }
            else
            {
                GuideText.instance.ResetText();
                SetLights(false);
            }
        }
        
    }
}
