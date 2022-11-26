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
            }
            else
            {
                GuideText.instance.ResetText();
            }
        }
        
    }
}
