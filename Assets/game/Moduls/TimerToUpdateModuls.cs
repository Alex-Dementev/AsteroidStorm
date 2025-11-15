using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerToUpdateModuls : MonoBehaviour
{
    public Text timerText;

    private const string TIME_KEY = "shop_last_update";
    private const string REFRESH_KEY = "shop_need_refresh";
    private const int HOURS = 24;

    void Start()
    {
        CheckTimer();
    }

    void Update()
    {
        UpdateTimerText();
    }

    void CheckTimer()
    {
        if (!PlayerPrefs.HasKey(TIME_KEY))
        {
            PlayerPrefs.SetString(TIME_KEY, DateTime.UtcNow.ToString());
            PlayerPrefs.SetInt(REFRESH_KEY, 1);
            PlayerPrefs.Save();
            return;
        }

        DateTime last = DateTime.Parse(PlayerPrefs.GetString(TIME_KEY));
        DateTime now = DateTime.UtcNow;

        TimeSpan passed = now - last;
        int cycles = (int)(passed.TotalHours / HOURS);

        if (cycles >= 1)
        {
            PlayerPrefs.SetInt(REFRESH_KEY, 1);

            DateTime newTime = last.AddHours(cycles * HOURS);
            PlayerPrefs.SetString(TIME_KEY, newTime.ToString());

            PlayerPrefs.Save();
        }
    }

    float GetHoursLeft()
    {
        DateTime last = DateTime.Parse(PlayerPrefs.GetString(TIME_KEY));
        DateTime now = DateTime.UtcNow;

        return Mathf.Clamp(HOURS - (float)(now - last).TotalHours, 0, HOURS);
    }

    void UpdateTimerText()
    {
        float hoursLeft = GetHoursLeft();

        int hours = Mathf.FloorToInt(hoursLeft);
        int minutes = Mathf.FloorToInt((hoursLeft - hours) * 60);

        if (hours <= 0 && minutes <= 0)
        {
            timerText.text = "Обновление: скоро";
        }
        else
        {
            timerText.text = $"Обновление через: {hours}ч {minutes}м";
        }
    }
}
