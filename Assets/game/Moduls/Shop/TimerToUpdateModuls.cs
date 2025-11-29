using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerToUpdateModuls : MonoBehaviour
{
    [Header("Настройки таймера")]
    private const float updateIntervalHours = 24f;

    [Header("UI и магазин")]
    public Text timerText;
    public UpdateModuls shopUpdater;

    [Header("Модули для первого показа")]
    public GameObject[] initialModules;

    [Header("Запуск таймера")]
    public bool startTimer = false;

    private const string NEXT_UPDATE_KEY = "shop_next_update";
    private const string TIMER_STARTED_KEY = "shop_timer_started";
    private const string SHOP_NEEDS_REFRESH = "shop_needs_refresh";

    private bool timerActive = false;

    void Start()
    {
        // показываем стартовые модули
        if (!PlayerPrefs.HasKey("shop_col1_rarity"))
        {
            foreach (var go in initialModules)
                if (go != null)
                    go.SetActive(true);
        }

        if (timerText != null)
            timerText.text = "";

        if (PlayerPrefs.GetInt(TIMER_STARTED_KEY, 0) == 1)
            startTimer = true;

        // включаем таймер
        if (startTimer && !timerActive)
            ActivateTimer();

        // проверяем, нужно ли обновить магазин сразу при старте
        if (PlayerPrefs.GetInt(SHOP_NEEDS_REFRESH, 0) == 1)
        {
            if (shopUpdater != null)
                shopUpdater.ForceRefresh();

            PlayerPrefs.SetInt(SHOP_NEEDS_REFRESH, 0); // сброс флага
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        if (!timerActive)
        {
            if (startTimer)
                ActivateTimer();
            else
                return;
        }

        float hoursLeft = GetHoursLeft();

        // === ВРЕМЯ ИСТЕКЛО ===
        if (hoursLeft <= 0f)
        {
            // ставим флаг необходимости обновления
            PlayerPrefs.SetInt(SHOP_NEEDS_REFRESH, 1);
            PlayerPrefs.Save();

            SetNextUpdateTimeSmart();
            hoursLeft = GetHoursLeft();
        }

        UpdateTimerText(hoursLeft);
    }

    private void ActivateTimer()
    {
        timerActive = true;
        PlayerPrefs.SetInt(TIMER_STARTED_KEY, 1);
        PlayerPrefs.Save();

        if (!PlayerPrefs.HasKey(NEXT_UPDATE_KEY))
            SetNextUpdateTimeSmart();

        UpdateTimerText();
    }

    // учёт пропущенного времени
    private void SetNextUpdateTimeSmart()
    {
        DateTime next;

        if (PlayerPrefs.HasKey(NEXT_UPDATE_KEY) &&
            DateTime.TryParse(PlayerPrefs.GetString(NEXT_UPDATE_KEY), out next))
        {
            // крутим время вперёд, пока не попадём в будущее
            while (next <= DateTime.UtcNow)
                next = next.AddHours(updateIntervalHours);
        }
        else
        {
            next = DateTime.UtcNow.AddHours(updateIntervalHours);
        }

        PlayerPrefs.SetString(NEXT_UPDATE_KEY, next.ToString("o"));
        PlayerPrefs.Save();
    }

    private float GetHoursLeft()
    {
        if (!PlayerPrefs.HasKey(NEXT_UPDATE_KEY))
            return updateIntervalHours;

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

    [ContextMenu("Start Timer")]
    public void EnableTimer()
    {
        startTimer = true;
        if (!timerActive)
            ActivateTimer();
    }
}
