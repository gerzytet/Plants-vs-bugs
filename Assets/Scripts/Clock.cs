using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public float minutesPerTick;

    public float minutes { private set; get; }
    [SerializeField] public int hours { private set; get; } = 13;
    [SerializeField] public int day = 1;
    public GameObject skipButton;
    public bool frozen = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!frozen)
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
        }

        GetComponent<TextMeshProUGUI>().text = GetDisplayString();
        skipButton.GetComponent<Button>().interactable = IsDay() && !frozen;
    }

    public bool IsDay()
    {
        return hours >= 6 && hours <= 20;
    }

    public void SkipToNight()
    {
        float skippedMinutes = 0;
        hours++;
        minutes = 0;
        skippedMinutes += 60 - minutes;
        while (hours < 21)
        {
            hours++;
            skippedMinutes += 60;
        }
        int skippedTicks = Mathf.FloorToInt(skippedMinutes / minutesPerTick);
        List<Plant> plants = new List<Plant>();
        foreach (GameObject p in Tags.GetAll("plant"))
        {
            plants.Add(p.GetComponent<Plant>());
        }
        for (int i = 0; i < skippedTicks; i++)
        {
            foreach (Plant p in plants)
            {
                p.Grow();
            }
        }
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
