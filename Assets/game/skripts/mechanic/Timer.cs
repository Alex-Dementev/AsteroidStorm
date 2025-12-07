using UnityEngine;
using System;

public class SmartBoostTimer : MonoBehaviour
{
    [Header("Название PlayerPrefs переменной (например Timer1boosts)")]
    public string TimerKey;

    [Header("Длительность таймера в секундах")]
    public int DurationSeconds = 3600; // 1 час по умолчанию

    private string endTimeKey;     // ключ для времени окончания
    private string textKey;        // ключ для текста "Xч Xм Xс"
    private bool finishedSaved = false;

    void Start()
    {
        endTimeKey = TimerKey + "_EndTime";
        textKey = TimerKey + "_Text";

        int status = PlayerPrefs.GetInt(TimerKey, 0);

        // ================================
        // 1) Проверка на команду "запустить"
        // ================================
        if (status == 1)
        {
            StartTimer();
            PlayerPrefs.SetInt(TimerKey, 0); // запускающий сигнал сбрасываем
        }

        // Если таймер был активен → продолжаем
        if (PlayerPrefs.HasKey(endTimeKey))
            UpdateTimer();
    }

    void Update()
    {
        if (PlayerPrefs.HasKey(endTimeKey))
            UpdateTimer();
    }

    // ============================================
    // Запуск таймера
    // ============================================
    void StartTimer()
    {
        long endTicks = DateTime.UtcNow.AddSeconds(DurationSeconds).Ticks;
        PlayerPrefs.SetString(endTimeKey, endTicks.ToString());
        PlayerPrefs.Save();
        finishedSaved = false;
    }

    // ============================================
    // Обновление таймера
    // ============================================
    void UpdateTimer()
    {
        long endTicks = long.Parse(PlayerPrefs.GetString(endTimeKey));
        long now = DateTime.UtcNow.Ticks;

        if (now >= endTicks)
        {
            // Таймер завершён
            if (!finishedSaved)
            {
                PlayerPrefs.SetInt(TimerKey, 2); // ставим статус "завершён"
                finishedSaved = true;
                PlayerPrefs.Save();
            }

            PlayerPrefs.SetString(textKey, "0ч 0м 0с");
            return;
        }

        // Считаем оставшееся время
        TimeSpan left = new TimeSpan(endTicks - now);

        string text =
            $"{left.Hours}ч {left.Minutes}м {left.Seconds}с";

        PlayerPrefs.SetString(textKey, text);
    }
}
