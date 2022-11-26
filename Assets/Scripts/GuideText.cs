using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuideText : MonoBehaviour
{
    public static GuideText instance;
    public string initialText;

    void Awake()
    {
        instance = this;
        initialText = GetComponent<TextMeshProUGUI>().text;
    }

    public void SetText(string s)
    {
        GetComponent<TextMeshProUGUI>().text = s;
    }

    public void ResetText()
    {
        GetComponent<TextMeshProUGUI>().text = initialText;
    }
}
