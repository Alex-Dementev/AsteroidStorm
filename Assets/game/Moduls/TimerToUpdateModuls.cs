using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerToUpdateModuls : MonoBehaviour
{
    [Header("UI и магазин")]
    public Text timerText;
    public UpdateModuls shopUpdater;

    [Header("Модули для первого показа")]
    public GameObject[] initialModules;

    [Header("Таймер")]
    public bool enableTimer = false; // галочка для запуска таймера
    public float hoursLength = 24f;  // например, 24 часа (или 1 час — как хочешь)

    private const string TIME_KEY = "shop_last_update";
    private bool updatedThisFrame = false;

    void Start()
    {
        // включаем стартовые модули
        foreach (var go in initialModules)
            if (go != null)
                go.SetActive(true);

        // Если таймер включён, но времени нет — записываем стартовое
        if (enableTimer && !PlayerPrefs.HasKey(TIME_KEY))
            SaveCurrentTime();
    }

    void Update()
    {
        if (!enableTimer) return;

        float hoursLeft = GetHoursLeft();
        UpdateTimerText(hoursLeft);

        if (hoursLeft <= 0f && !updatedThisFrame)
        {
            if (shopUpdater != null)
                shopUpdater.ForceRefresh();

            SaveCurrentTime();
            updatedThisFrame = true;
        }
        else if (hoursLeft > 0f)
        {
            updatedThisFrame = false;
        }
    }

    // --- Сохраняем текущее время в секундах ---
    void SaveCurrentTime()
    {
        long unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        PlayerPrefs.SetString(TIME_KEY, unixTime.ToString());
        PlayerPrefs.Save();
    }

    // --- Считаем сколько осталось времени до обновления ---
    float GetHoursLeft()
    {
        string saved = PlayerPrefs.GetString(TIME_KEY, "");
        if (string.IsNullOrEmpty(saved))
            return hoursLength;

        long lastUnix;
        if (!long.TryParse(saved, out lastUnix))
            return hoursLength;

        long nowUnix = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        float hoursPassed = (nowUnix - lastUnix) / 3600f;

        return Mathf.Clamp(hoursLength - hoursPassed, 0f, hoursLength);
    }

    // --- Пишем на UI оставшееся время ---
    void UpdateTimerText(float hoursLeft)
    {
        if (timerText == null) return;

        int h = Mathf.FloorToInt(hoursLeft);
        int m = Mathf.FloorToInt((hoursLeft - h) * 60f);

        timerText.text = $"Обновление через: {h}ч {m}м";
    }
}
