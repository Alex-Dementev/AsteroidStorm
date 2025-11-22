using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerToUpdateModuls : MonoBehaviour
{
    [Header("UI и магазин")]
    public Text timerText;
    public UpdateModuls shopUpdater; // компонент магазина

    [Header("Модули для первого показа")]
    public GameObject[] initialModules; // просто массив объектов, которые включатся при первом входе

    [Header("Таймер")]
    public bool enableTimer = false;   // галочка в инспекторе — включить таймер
    public float hoursLength = 1f;     // длительность таймера в часах

    private const string TIME_KEY = "shop_last_update";
    private bool updatedThisFrame = false;

    void Start()
    {
        // Включаем выбранные объекты при первом входе
        foreach (var go in initialModules)
            if (go != null)
                go.SetActive(true);

        // Если галочка на таймер → сохраняем стартовое время
        if (enableTimer)
            SaveCurrentTime();
    }

    void Update()
    {
        if (!enableTimer) return;

        float hoursLeft = GetHoursLeft();
        UpdateTimerText(hoursLeft);

        if (hoursLeft <= 0f && !updatedThisFrame)
        {
            // обновляем магазин
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

    void SaveCurrentTime()
    {
        PlayerPrefs.SetString(TIME_KEY, DateTime.UtcNow.ToString());
        PlayerPrefs.Save();
    }

    float GetHoursLeft()
    {
        DateTime last;
        if (!DateTime.TryParse(PlayerPrefs.GetString(TIME_KEY, ""), out last))
            last = DateTime.UtcNow;

        return Mathf.Clamp(hoursLength - (float)(DateTime.UtcNow - last).TotalHours, 0f, hoursLength);
    }

    void UpdateTimerText(float hoursLeft)
    {
        int h = Mathf.FloorToInt(hoursLeft);
        int m = Mathf.FloorToInt((hoursLeft - h) * 60f);
        if (timerText != null)
            timerText.text = $"Обновление через: {h}ч {m}м";
    }
}
