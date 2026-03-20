using UnityEngine;
using Unity.Notifications.Android;
using System;
using UnityEngine.SceneManagement;

public class ShopNotification : MonoBehaviour
{
    private string[] Names = { "Никита", "Рома", "Алиса" };
    private string[] Messages =
    {
        "В магазине появились новые модули. Стоит заглянуть.",
        "Поступление оборудования: новые модули уже доступны.",
        "Магазин обновился. Добавлены новые модули.",
        "Похоже, привезли свежие модули. Проверь магазин.",
        "Новые модули уже на складе. Успей посмотреть."
    };
    private int TimePlus;

    void Start()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "Shop",
            Name = "Магазин модулей",
            Importance = Importance.Default,
            Description = "Напоминание об обновлении модулей"
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        // удаляем старые уведомления
        for (int i = 0; i < 5; i++)
        {
            string key = "ShopNotificationID_" + i;

            if (PlayerPrefs.HasKey(key))
            {
                int id = PlayerPrefs.GetInt(key);
                AndroidNotificationCenter.CancelNotification(id);
                PlayerPrefs.DeleteKey(key);
            }
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            if (PlayerPrefs.GetInt("shop_timer_started", 0) == 1)
                CreateNotification();
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                string key = "ShopNotificationID_" + i;

                if (PlayerPrefs.HasKey(key))
                {
                    int id = PlayerPrefs.GetInt(key);
                    AndroidNotificationCenter.CancelNotification(id);
                    PlayerPrefs.DeleteKey(key);
                }
            }

            PlayerPrefs.Save();
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        if (PlayerPrefs.GetInt("shop_timer_started", 0) == 1)
            CreateNotification();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (PlayerPrefs.GetInt("shop_timer_started", 0) == 1)
            CreateNotification();
    }

    void CreateNotification()
    {
        Debug.Log("Shop notifications created");
        
        for (int i = 0; i < 5; i++)
        {
            string key = "ShopNotificationID_" + i;

            if (PlayerPrefs.HasKey(key))
            {
                int id = PlayerPrefs.GetInt(key);
                AndroidNotificationCenter.CancelNotification(id);
                PlayerPrefs.DeleteKey(key);
            }
        }

            int delay = PlayerPrefs.GetInt("ShopNotificationSeconds", 0);

            TimePlus = 0;

            for (int i = 0; i < 5; i++)
            {
                int nameIndex = UnityEngine.Random.Range(0, Names.Length);
                int messageIndex = UnityEngine.Random.Range(0, Messages.Length);

                AndroidNotification notification = new AndroidNotification()
                {
                    Title = Names[nameIndex],
                    Text = Messages[messageIndex],
                    FireTime = DateTime.Now.AddSeconds(delay + TimePlus),
                    SmallIcon = "ic_notification",
                    LargeIcon = "icon"
                };

                int id = AndroidNotificationCenter.SendNotification(notification, "Shop");

                TimePlus += 21600;

                PlayerPrefs.SetInt("ShopNotificationID_" + i, id);
            }
    }
}