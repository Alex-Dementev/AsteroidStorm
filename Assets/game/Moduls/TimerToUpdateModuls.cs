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
    public bool startTimer = false; // ставим true в инспекторе — таймер стартует

    private const string NEXT_UPDATE_KEY = "shop_next_update";
    private const string TIMER_STARTED_KEY = "shop_timer_started";
    private bool timerActive = false;

    void Start()
    {
        // показываем стартовые модули только если нет сохранения
        if (!PlayerPrefs.HasKey("shop_col1_rarity"))
        {
            foreach (var go in initialModules)
                if (go != null)
                    go.SetActive(true);
        }

        // очищаем UI
        if (timerText != null)
            timerText.text = "";

        // таймер уже был активирован ранее?
        if (PlayerPrefs.GetInt(TIMER_STARTED_KEY, 0) == 1)
            startTimer = true;

        if (startTimer && !timerActive)
            ActivateTimer();
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

        if (hoursLeft <= 0f)
        {
            if (shopUpdater != null)
                shopUpdater.ForceRefresh();

            SetNextUpdateTime();
            hoursLeft = updateIntervalHours;
        }

        UpdateTimerText(hoursLeft);
    }

    private void ActivateTimer()
    {
        timerActive = true;

        PlayerPrefs.SetInt(TIMER_STARTED_KEY, 1);
        PlayerPrefs.Save();

        if (!PlayerPrefs.HasKey(NEXT_UPDATE_KEY))
            SetNextUpdateTime();

        UpdateTimerText();
    }

    private void SetNextUpdateTime()
    {
        DateTime nextUpdate = DateTime.UtcNow.AddHours(updateIntervalHours);
        PlayerPrefs.SetString(NEXT_UPDATE_KEY, nextUpdate.ToString("o"));
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

    [ContextMenu("Start Timer")]
    public void EnableTimer()
    {
        startTimer = true;
        if (!timerActive)
            ActivateTimer();
    }
}
