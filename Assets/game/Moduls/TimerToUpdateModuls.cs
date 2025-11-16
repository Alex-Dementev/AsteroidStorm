using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerToUpdateModuls : MonoBehaviour
{
    public Text timerText;
    public UpdateModuls shopUpdater; // привяжи компонент UpdateModuls на той же сцене

    private const string TIME_KEY = "shop_last_update";
    private const float HOURS = 60f; // 15 минут для теста
    private bool updatedThisFrame = false;

    void Start()
    {
        CheckTimer();
    }

    void Update()
    {
        UpdateTimerText();

        if (GetHoursLeft() <= 0f && !updatedThisFrame)
        {
            if (shopUpdater != null)
                shopUpdater.ForceRefresh(); // обновляем магаз сразу

            PlayerPrefs.SetString(TIME_KEY, DateTime.UtcNow.ToString());
            PlayerPrefs.Save();

            updatedThisFrame = true; // чтобы не вызывалось каждый кадр
        }
        else if (GetHoursLeft() > 0f)
        {
            updatedThisFrame = false;
        }
    }

    void CheckTimer()
    {
        DateTime last;
        string lastStr = PlayerPrefs.GetString(TIME_KEY, "");

        if (!DateTime.TryParse(lastStr, out last))
        {
            last = DateTime.UtcNow;
            PlayerPrefs.SetString(TIME_KEY, last.ToString());
            PlayerPrefs.Save();
        }
    }

    float GetHoursLeft()
    {
        DateTime last;
        if (!DateTime.TryParse(PlayerPrefs.GetString(TIME_KEY, ""), out last))
            last = DateTime.UtcNow;

        return Mathf.Clamp(HOURS - (float)(DateTime.UtcNow - last).TotalHours, 0f, HOURS);
    }

    void UpdateTimerText()
    {
        float hoursLeft = GetHoursLeft();
        int hours = Mathf.FloorToInt(hoursLeft);
        int minutes = Mathf.FloorToInt((hoursLeft - hours) * 60f);
        timerText.text = $"Обновление через: {hours}ч {minutes}м";
    }
}
