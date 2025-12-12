using UnityEngine;
using System;
using System.Collections;

public class SmartCreditsTimer : MonoBehaviour
{
    [Header("Название PlayerPrefs (напр. CreditTimer1)")]
    public string TimerKey;

    [Header("Длительность таймера в МИНУТАХ")]
    public int DurationMinutes = 60;

    [Header("Применять ли пропущенное время к новому таймеру")]
    public bool ApplyLostTime = true;

    [Header("Если отсутствовал больше дней — таймер не уменьшается")]
    public int MaxOfflineDays = 3;

    [Header("Полностью отключить время при статусе 3?")]
    public bool HardDisable = true;

    private string endTimeKey;
    private string lastLoginKey;
    private string textKey;
    private string secondsLeftKey;
    private string lostTimeKey;

    private bool finishedSaved = false;

    void Start()
    {
        endTimeKey = TimerKey + "_EndTime";
        lastLoginKey = TimerKey + "_LastLogin";
        textKey = TimerKey + "_Text";
        secondsLeftKey = TimerKey + "_SecondsLeft";
        lostTimeKey = TimerKey + "_LostTime";

        HandleOfflineTime();
    }

    void Update()
    {
        int status = PlayerPrefs.GetInt(TimerKey, 0);

        // ================================
        //       ПОЛНОЕ ОТКЛЮЧЕНИЕ (3)
        // ================================
        if (status == 3)
        {
            // Просто выключаем таймер, НИЧЕГО не удаляем
            if (HardDisable)
            {
                PlayerPrefs.SetInt(secondsLeftKey, 0);
                PlayerPrefs.SetString(textKey, "0д 0ч 0м");
            }

            // Сбрасываем основное состояние
            PlayerPrefs.SetInt(TimerKey, 0);
            PlayerPrefs.Save();
            return;
        }

        // ================================
        //              СТАРТ (1)
        // ================================
        if (status == 1)
        {
            StartCoroutine(StartTimerWithDelay());
            PlayerPrefs.SetInt(TimerKey, 0);
            PlayerPrefs.Save();
        }

        // ================================
        //            ПРОДОЛЖЕНИЕ
        // ================================
        if (PlayerPrefs.HasKey(endTimeKey))
            UpdateTimer();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString(lastLoginKey, DateTime.UtcNow.Ticks.ToString());
        PlayerPrefs.Save();
    }

    // ================================
    // 1) ОБРАБОТКА ОФФЛАЙН ВРЕМЕНИ
    // ================================
    void HandleOfflineTime()
    {
        DateTime now = DateTime.UtcNow;

        if (!PlayerPrefs.HasKey(lastLoginKey))
        {
            PlayerPrefs.SetString(lastLoginKey, now.Ticks.ToString());
            PlayerPrefs.Save();
            return;
        }

        long lastTicks = long.Parse(PlayerPrefs.GetString(lastLoginKey));
        DateTime lastOnline = new DateTime(lastTicks);
        TimeSpan offline = now - lastOnline;

        if (offline.TotalDays > MaxOfflineDays)
        {
            PlayerPrefs.SetString(lastLoginKey, now.Ticks.ToString());
            PlayerPrefs.Save();
            return;
        }

        // Если таймер был активен
        if (PlayerPrefs.HasKey(endTimeKey))
        {
            long endTicks = long.Parse(PlayerPrefs.GetString(endTimeKey));
            DateTime endTime = new DateTime(endTicks);

            if (now > endTime)
            {
                TimeSpan afterEnd = now - endTime;

                PlayerPrefs.SetInt(lostTimeKey, (int)afterEnd.TotalSeconds);
                PlayerPrefs.SetInt(TimerKey, 2); // таймер завершён
                PlayerPrefs.Save();
            }
        }

        PlayerPrefs.SetString(lastLoginKey, now.Ticks.ToString());
        PlayerPrefs.Save();
    }

    // ================================
    // 2) СТАРТ ТАЙМЕРА С ЗАДЕРЖКОЙ
    // ================================
    IEnumerator StartTimerWithDelay()
    {
        yield return new WaitForSeconds(1);

        int lost = PlayerPrefs.GetInt(lostTimeKey, 0);
        int totalSeconds = DurationMinutes * 60;

        if (ApplyLostTime && lost > 0)
        {
            totalSeconds -= lost;
            if (totalSeconds < 0) totalSeconds = 0;

            PlayerPrefs.DeleteKey(lostTimeKey);
        }

        long endTicks = DateTime.UtcNow.AddSeconds(totalSeconds).Ticks;

        PlayerPrefs.SetString(endTimeKey, endTicks.ToString());
        PlayerPrefs.Save();

        finishedSaved = false;
    }

    // ================================
    // 3) ОБНОВЛЕНИЕ ТАЙМЕРА
    // ================================
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
                finishedSaved = true;
                PlayerPrefs.Save();
            }

            PlayerPrefs.SetString(textKey, "0д 0ч 0м");
            PlayerPrefs.SetInt(secondsLeftKey, 0);
            PlayerPrefs.Save();
            return;
        }

        // === ТАЙМЕР АКТИВЕН ===
        PlayerPrefs.SetInt(TimerKey, 4); // <<< ТВОЁ УСЛОВИЕ
        PlayerPrefs.Save();

        TimeSpan left = new TimeSpan(endTicks - now);
        string text = "До конца времени погашения: " + $"{left.Days}д {left.Hours}ч {left.Minutes}м";

        PlayerPrefs.SetString(textKey, text);
        PlayerPrefs.SetInt(secondsLeftKey, (int)left.TotalSeconds);
        PlayerPrefs.Save();
    }

}
