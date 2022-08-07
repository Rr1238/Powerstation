using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Date : MonoBehaviour
{
    [SerializeField] private float time_day_s;

    [SerializeField] private Text date;

    public int day;
    public int month;
    public int year;

    private float timer;

    void Update()
    {
        if (timer + time_day_s <= Time.realtimeSinceStartup)
        {
            day++;
            timer = Time.realtimeSinceStartup;
            if (day > 30)
            {
                day = day - 30;
                month++;
                if (month > 12) 
                {
                    month = month - 12;
                    year++;
                }

            }
            date.text = day.ToString() + '.' + month.ToString() + '.' + year.ToString();
        }

        

    }
}
