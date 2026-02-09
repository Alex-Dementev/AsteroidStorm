using UnityEngine;
using System;

public class RandomPercent : MonoBehaviour
{
    [Header("PlayerPrefs для ЧИСЛА")]
    public string ValueKey = "RandomNumber";

    private string lastUpdateKey;

    void Start()
    {
        lastUpdateKey = ValueKey + "_LastUpdate";

        HandleOfflineHours();
    }

    void Update()
    {
        HandleOnlineHour();
    }

    // ============================
    // Обработка ОФФЛАЙН часов
    // ============================
    void HandleOfflineHours()
    {
        DateTime now = DateTime.UtcNow;

        if (!PlayerPrefs.HasKey(lastUpdateKey))
        {
            PlayerPrefs.SetString(lastUpdateKey, now.Ticks.ToString());
            PlayerPrefs.Save();
            return;
        }

        DateTime last = new DateTime(long.Parse(PlayerPrefs.GetString(lastUpdateKey)));
        TimeSpan diff = now - last;

        int hours = (int)diff.TotalHours;

        if (hours <= 0) return;

        ApplyRandomChanges(hours);

        PlayerPrefs.SetString(lastUpdateKey, now.Ticks.ToString());
        PlayerPrefs.Save();
    }

    // ============================
    // Онлайн изменение каждый час
    // ============================
    void HandleOnlineHour()
    {
        if (!PlayerPrefs.HasKey(lastUpdateKey))
            return;

        DateTime last = new DateTime(long.Parse(PlayerPrefs.GetString(lastUpdateKey)));
        DateTime now = DateTime.UtcNow;

        if ((now - last).TotalHours >= 1f)
        {
            ApplyRandomChanges(1);

            PlayerPrefs.SetString(lastUpdateKey, now.Ticks.ToString());
            PlayerPrefs.Save();
        }
    }

    // ============================
    // Основная логика изменения
    // ============================
    void ApplyRandomChanges(int hoursPassed)
    {
        int value = PlayerPrefs.GetInt(ValueKey, 7); // любое стартовое

        for (int i = 0; i < hoursPassed; i++)
        {
            int delta = UnityEngine.Random.Range(-3, 4); // -3…+3

            value += delta;

            // Clamp 4–20
            if (value < 4) value = 4;
            if (value > 20) value = 20;
        }

        PlayerPrefs.SetInt(ValueKey, value);
        PlayerPrefs.Save();
    }
}
