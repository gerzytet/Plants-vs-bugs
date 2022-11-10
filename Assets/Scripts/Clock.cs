using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float minutesPerTick;

    public float minutes { private set; get; }
    [SerializeField] public int hours { private set; get; } = 13;
    [SerializeField] private int day = 1;

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
    }

    public bool IsDay()
    {
        return hours >= 6 && hours <= 20;
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
