using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerToUpdateModuls : MonoBehaviour
{
    [Header("Настройки таймера")]
    public float updateIntervalHours = 1f; // время обновления в часах

    [Header("UI и магазин")]
    public Text timerText;
    public UpdateModuls shopUpdater; // компонент магазина

    [Header("Модули для первого показа")]
    public GameObject[] initialModules;

    [Header("Запуск таймера")]
    public bool startTimer = false; // ставим true в инспекторе — таймер стартует и больше не остановится

    private const string NEXT_UPDATE_KEY = "shop_next_update";
    private const string TIMER_STARTED_KEY = "shop_timer_started";
    private bool timerActive = false; // внутренний флаг, чтобы таймер начал работать один раз

    void Start()
    {
        // Включаем начальные объекты
        foreach (var go in initialModules)
            if (go != null)
                go.SetActive(true);

        // UI пустой пока таймер не стартан
        if (timerText != null)
            timerText.text = "";

        // Проверяем PlayerPrefs — если таймер уже был разрешён ранее
        if (PlayerPrefs.GetInt(TIMER_STARTED_KEY, 0) == 1)
            startTimer = true;

        if (startTimer && !timerActive)
            ActivateTimer();
    }

    void Update()
    {
        if (!timerActive)
        {
            // Проверяем, если переменная была включена после старта
            if (startTimer)
                ActivateTimer();
            else
                return;
        }

        float hoursLeft = GetHoursLeft();

        if (hoursLeft <= 0f)
        {
            // Время вышло — обновляем магазин
            if (shopUpdater != null)
                shopUpdater.ForceRefresh();

            SetNextUpdateTime();
            hoursLeft = updateIntervalHours; // сброс для UI
        }

        UpdateTimerText(hoursLeft);
    }

    private void ActivateTimer()
    {
        timerActive = true;

        // Сохраняем факт старта таймера
        PlayerPrefs.SetInt(TIMER_STARTED_KEY, 1);
        PlayerPrefs.Save();

        // Если нет сохранённого времени — ставим на сейчас + интервал
        if (!PlayerPrefs.HasKey(NEXT_UPDATE_KEY))
            SetNextUpdateTime();

        UpdateTimerText();
    }

    private void SetNextUpdateTime()
    {
        DateTime nextUpdate = DateTime.UtcNow.AddHours(updateIntervalHours);
        PlayerPrefs.SetString(NEXT_UPDATE_KEY, nextUpdate.ToString("o")); // универсальный ISO формат
        PlayerPrefs.Save();
    }

    private float GetHoursLeft()
    {
        if (!DateTime.TryParse(PlayerPrefs.GetString(NEXT_UPDATE_KEY, ""), out DateTime next))
            return updateIntervalHours;

        double hoursLeft = (next - DateTime.UtcNow).TotalHours;
        return Mathf.Max(0f, (float)hoursLeft);
    }

    private void UpdateTimerText(float hoursLeft = -1f)
    {
        if (timerText == null) return;

        if (hoursLeft < 0f)
            hoursLeft = GetHoursLeft();

        int hours = Mathf.FloorToInt(hoursLeft);
        int minutes = Mathf.FloorToInt((hoursLeft - hours) * 60f);

        timerText.text = $"Обновление через: {hours}ч {minutes}м";
    }

    // Публичный метод для запуска таймера из другого скрипта
    [ContextMenu("Start Timer")]
    public void EnableTimer()
    {
        startTimer = true;
        if (!timerActive)
            ActivateTimer();
    }
}
