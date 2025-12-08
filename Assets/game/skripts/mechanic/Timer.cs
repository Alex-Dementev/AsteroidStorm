using UnityEngine;
using System;

public class SmartBoostTimer : MonoBehaviour
{
    [Header("Название PlayerPrefs переменной (например Boost1Timer)")]
    public string TimerKey;

    [Header("Длительность таймера в секундах")]
    public int DurationSeconds = 3600; // 1 час

    private string endTimeKey; 
    private string textKey;    
    private string secondsLeftKey;

    private bool finishedSaved = false;

    void Start()
    {
        endTimeKey = TimerKey + "_EndTime";
        textKey = TimerKey + "_Text";
        secondsLeftKey = TimerKey + "_SecondsLeft";

        // Если таймер был активен — продолжаем
        if (PlayerPrefs.HasKey(endTimeKey))
        {
            UpdateTimer();
        }
    }

    void Update()
    {
        // Проверка на запуск
        int status = PlayerPrefs.GetInt(TimerKey, 0);

        if (status == 1)
        {
            StartTimer();
            PlayerPrefs.SetInt(TimerKey, 0); 
            PlayerPrefs.Save();
        }

        // Если таймер активен — обновляем
        if (PlayerPrefs.HasKey(endTimeKey))
        {
            UpdateTimer();
        }
    }

    // ======== Запуск ========
    void StartTimer()
    {
        long endTicks = DateTime.UtcNow.AddSeconds(DurationSeconds).Ticks;

        PlayerPrefs.SetString(endTimeKey, endTicks.ToString());
        PlayerPrefs.Save();

        finishedSaved = false;
    }

    // ======== Обновление ========
    void UpdateTimer()
    {
        long endTicks = long.Parse(PlayerPrefs.GetString(endTimeKey));
        long now = DateTime.UtcNow.Ticks;

        // === ТАЙМЕР ЗАКОНЧИЛСЯ ===
        if (now >= endTicks)
        {
            if (!finishedSaved)
            {
                PlayerPrefs.SetInt(TimerKey, 2);  // завершён
                PlayerPrefs.Save();
                finishedSaved = true;
            }

            PlayerPrefs.SetString(textKey, "0ч 0м 0с");
            PlayerPrefs.SetInt(secondsLeftKey, 0);

            // Удаляем активный таймер
            PlayerPrefs.DeleteKey(endTimeKey);
            PlayerPrefs.Save();

            return;
        }

        // === Считаем оставшееся ===
        TimeSpan left = new TimeSpan(endTicks - now);

        string text = $"{left.Hours}ч {left.Minutes}м {left.Seconds}с";

        PlayerPrefs.SetString(textKey, text);
        PlayerPrefs.SetInt(secondsLeftKey, (int)left.TotalSeconds);
        PlayerPrefs.Save();
    }
}
