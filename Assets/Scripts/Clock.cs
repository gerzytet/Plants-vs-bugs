using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public float minutesPerTick;

    public float minutes { private set; get; }
    [SerializeField] public int hours { private set; get; } = 13;
    [SerializeField] public int day {private set; get; } = 1;
    public GameObject skipButton;

    // Update is called once per frame
    void FixedUpdate()
    {
        minutes += minutesPerTick;
        if (minutes >= 60)
        {
            minutes = 0;
            if (hours == 5)
            {
                day++;
            }
            hours++;
        }
        if (hours >= 24)
        {
            hours = 0;
        }

        GetComponent<TextMeshProUGUI>().text = GetDisplayString();
        skipButton.GetComponent<Button>().interactable = IsDay();
    }

    public bool IsDay()
    {
        return hours >= 6 && hours <= 20;
    }

    public void SkipToNight()
    {
        hours = 21;
    }

    string GetDisplayString()
    {
        string s = "";
        s += IsDay() ? "Day " : "Night ";
        s += day.ToString();
        s += "  ";

        bool am = hours < 12;
        int h = hours % 12;
        if (h == 0) h = 12;
        s += h.ToString();
        s += am ? " AM" : " PM";
        return s;
    }
}
