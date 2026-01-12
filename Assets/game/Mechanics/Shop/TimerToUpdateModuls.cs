using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopTimerSmart : MonoBehaviour
{
    [Header("UI и магазин")]
    public Text timerText;
    public UpdateModuls shopUpdater;

    [Header("Модули для первого показа")]
    public GameObject[] initialModules;

    [Header("Запуск таймера (после обучения)")]
    public bool startTimer = false;

    [Header("Интервал обновления магазина (ЧАСЫ)")]
    public int UpdateIntervalHours = 4;

    private const string TIMER_STARTED_KEY = "shop_timer_started";
    private const string END_TIME_KEY = "shop_end_time_ticks";
    private const string LAST_LOGIN_KEY = "shop_last_login_ticks";
    private const string SHOP_NEEDS_REFRESH = "shop_needs_refresh";

    private bool timerActive;

    // ================================
    void Start()
    {
        // стартовые модули (первый запуск)
        if (!PlayerPrefs.HasKey("shop_col1_rarity"))
        {
            foreach (var go in initialModules)
                if (go != null)
                    go.SetActive(true);
        }

        if (PlayerPrefs.GetInt(TIMER_STARTED_KEY, 0) == 1)
            startTimer = true;

        HandleOfflineTime();

        if (startTimer)
            EnsureTimer();

        // если оффлайн-обновление — обновляем СРАЗУ
        if (PlayerPrefs.GetInt(SHOP_NEEDS_REFRESH, 0) == 1)
        {
            shopUpdater.ForceRefresh();
            PlayerPrefs.SetInt(SHOP_NEEDS_REFRESH, 0);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        if (!timerActive)
            return;

        UpdateTimer();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString(LAST_LOGIN_KEY, DateTime.UtcNow.Ticks.ToString());
        PlayerPrefs.Save();
    }

    // ================================
    // ОФФЛАЙН ЛОГИКА
    // ================================
    void HandleOfflineTime()
    {
        DateTime now = DateTime.UtcNow;

        if (!PlayerPrefs.HasKey(LAST_LOGIN_KEY))
        {
            PlayerPrefs.SetString(LAST_LOGIN_KEY, now.Ticks.ToString());
            PlayerPrefs.Save();
            return;
        }

        if (PlayerPrefs.HasKey(END_TIME_KEY))
        {
            long endTicks = long.Parse(PlayerPrefs.GetString(END_TIME_KEY));
            DateTime endTime = new DateTime(endTicks);

            if (now >= endTime)
            {
                PlayerPrefs.SetInt(SHOP_NEEDS_REFRESH, 1);

                while (endTime <= now)
                    endTime = endTime.AddHours(UpdateIntervalHours);

                PlayerPrefs.SetString(END_TIME_KEY, endTime.Ticks.ToString());
                PlayerPrefs.Save();
            }
        }

        PlayerPrefs.SetString(LAST_LOGIN_KEY, now.Ticks.ToString());
        PlayerPrefs.Save();
    }

    // ================================
    // СОЗДАНИЕ ТАЙМЕРА
    // ================================
    void EnsureTimer()
    {
        if (timerActive)
            return;

        timerActive = true;
        PlayerPrefs.SetInt(TIMER_STARTED_KEY, 1);

        if (!PlayerPrefs.HasKey(END_TIME_KEY))
        {
            long endTicks = DateTime.UtcNow
                .AddHours(UpdateIntervalHours)
                .Ticks;

            PlayerPrefs.SetString(END_TIME_KEY, endTicks.ToString());
        }

        PlayerPrefs.Save();
    }

    // ================================
    // ОБНОВЛЕНИЕ ТАЙМЕРА
    // ================================
    void UpdateTimer()
    {
        long endTicks = long.Parse(PlayerPrefs.GetString(END_TIME_KEY));
        long now = DateTime.UtcNow.Ticks;

        if (now >= endTicks)
        {
            // обновляем магазин
            shopUpdater.ForceRefresh();

            DateTime endTime = new DateTime(endTicks);
            while (endTime <= DateTime.UtcNow)
                endTime = endTime.AddHours(UpdateIntervalHours);

            endTicks = endTime.Ticks; // ★ FIX
            PlayerPrefs.SetString(END_TIME_KEY, endTicks.ToString());
            PlayerPrefs.Save();
        }

        TimeSpan left = new TimeSpan(endTicks - now);
        UpdateTimerText(left);
    }

    // ================================
    // UI
    // ================================
    void UpdateTimerText(TimeSpan left)
    {
        if (timerText == null)
            return;

        if (left.TotalSeconds < 0)
            left = TimeSpan.Zero;

        int totalHours = left.Days * 4 + left.Hours;
        timerText.text = $"Обновление через: {totalHours}ч {left.Minutes}м";
    }

    // ================================
    // ВЫЗЫВАЕТ ОБУЧЕНИЕ
    // ================================
    public void EnableTimer()
    {
        startTimer = true;
        EnsureTimer();
    }

    // ================================
    // ★ ПУБЛИЧЕСКИЙ МЕТОД: СДЕЛАТЬ ОСТАТОК = 5 СЕКУНД
    // ================================
    public void ReduceTimerBy20Percent()
    {
        int Games = PlayerPrefs.GetInt("ShopStartsGame");
        Games += 2;

        if(PlayerPrefs.GetInt("ShopBoost", 0) == 2 && PlayerPrefs.GetInt("ShopStartsGame") < PlayerPrefs.GetInt("allgames"))
        {
            if (!PlayerPrefs.HasKey(END_TIME_KEY))
                return;

            PlayerPrefs.SetInt("ShopStartsGame", PlayerPrefs.GetInt("allgames"));
            PlayerPrefs.SetInt("ShopBoost", 1);

            long endTicks = long.Parse(PlayerPrefs.GetString(END_TIME_KEY));
            long nowTicks = DateTime.UtcNow.Ticks;

            // сколько осталось
            long remainingTicks = endTicks - nowTicks;

            if (remainingTicks <= 0)
                return;

            // минус 20%
            long reducedTicks = (long)(remainingTicks * 0.65f);

            long newEndTicks = nowTicks + reducedTicks;

            PlayerPrefs.SetString(END_TIME_KEY, newEndTicks.ToString());
            PlayerPrefs.Save();
        }
    }

}
