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

        // Если таймер уже был запущен ранее — продолжаем
        if (PlayerPrefs.HasKey(endTimeKey))
        {
            PlayerPrefs.SetInt(TimerKey, 3); // таймер идёт
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        int status = PlayerPrefs.GetInt(TimerKey, 0);

        // === ЗАПРОС НА ЗАПУСК ===
        if (status == 1)
        {
            StartTimer();
        }

        // === ЕСЛИ ТАЙМЕР ИДЁТ ===
        if (PlayerPrefs.HasKey(endTimeKey))
        {
            UpdateTimer();
        }
    }


    public void RestartTimer()
    {
        // Удаляем старый таймер
        PlayerPrefs.DeleteKey(endTimeKey);
        PlayerPrefs.DeleteKey(textKey);
        PlayerPrefs.DeleteKey(secondsLeftKey);

        // Запускаем заново
        long endTicks = DateTime.UtcNow.AddSeconds(DurationSeconds).Ticks;
        PlayerPrefs.SetString(endTimeKey, endTicks.ToString());

        PlayerPrefs.SetInt(TimerKey, 3); // таймер идёт
        PlayerPrefs.Save();

        finishedSaved = false;
    }



    // ======== ЗАПУСК ТАЙМЕРА ========
    void StartTimer()
    {
        long endTicks = DateTime.UtcNow.AddSeconds(DurationSeconds).Ticks;

        PlayerPrefs.SetString(endTimeKey, endTicks.ToString());
        PlayerPrefs.SetInt(TimerKey, 3); // таймер идёт
        PlayerPrefs.Save();

        finishedSaved = false;
    }

    // ======== ОБНОВЛЕНИЕ ========
    void UpdateTimer()
    {
        long endTicks = long.Parse(PlayerPrefs.GetString(endTimeKey));
        long now = DateTime.UtcNow.Ticks;

        // === ТАЙМЕР ЗАКОНЧИЛСЯ ===
        if (now >= endTicks)
        {
            if (!finishedSaved)
            {
                PlayerPrefs.SetInt(TimerKey, 2); // завершён
                PlayerPrefs.SetInt(secondsLeftKey, 0);
                PlayerPrefs.SetString(textKey, "0ч 0м 0с");

                PlayerPrefs.DeleteKey(endTimeKey);
                PlayerPrefs.Save();

                finishedSaved = true;
            }
            return;
        }

        // === СЧИТАЕМ ОСТАВШЕЕСЯ ВРЕМЯ ===
        TimeSpan left = new TimeSpan(endTicks - now);

        string text = $"{left.Hours}ч {left.Minutes}м {left.Seconds}с";

        PlayerPrefs.SetString(textKey, text);
        PlayerPrefs.SetInt(secondsLeftKey, (int)left.TotalSeconds);
        PlayerPrefs.Save();
    }
}
    