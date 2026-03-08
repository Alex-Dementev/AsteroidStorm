using UnityEngine;
using Unity.Notifications.Android;
using System;

public class ShopNotification : MonoBehaviour
{
    private string[] Names = { "Никита", "Рома", "Алиса" };
    private string[] Messages =
    {
        "В магазине появились новые модули. Стоит заглянуть.",
        "Поступление оборудования: новые модули уже доступны.",
        "Магазин обновился. Добавлены новые модули.",
        "Похоже, привезли свежие модули. Проверь магазин.",
        "Новые модули уже на складе. Успей посмотреть.",
        "Обновление ассортимента. Магазин пополнился модулями.",
        "В продаже появились новые корабельные модули.",
        "Поставщики привезли новые модули. Загляни в магазин.",
        "Каталог модулей обновлён. Есть интересные вещи.",
        "В магазине новые технологии. Возможно пригодятся.",
        "Обнаружены новые модули в продаже.",
        "Магазин получил новую партию оборудования.",
        "Добавлены новые модули. Проверь доступные улучшения.",
        "Появились дополнительные модули для корабля.",
        "Склад обновлён. Новые модули уже в магазине.",
        "Есть новые модули. Может пригодятся в миссии.",
        "Магазин снова обновился. Посмотри, что привезли.",
        "Новые компоненты уже доступны для покупки.",
        "Поступление модулей подтверждено. Загляни в магазин.",
        "В ассортименте появились новые улучшения.",
        "Есть новые модули для установки.",
        "Поставщики не спят. В магазине новые модули.",
        "Каталог обновился. Доступны новые модули.",
        "Свежая партия оборудования уже в продаже.",
        "Проверь магазин. Там появились новые модули.",
        "Новые модули готовы к установке."
    };

    void Start()
    {
        // Регистрируем канал
        var channel = new AndroidNotificationChannel()
        {
            Id = "Shop",
            Name = "Магазин модулей",
            Importance = Importance.Default,
            Description = "Напоминание об обновлении модулей в магазине",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        // Удаляем старое уведомление, если есть
        if (PlayerPrefs.HasKey("ShopNotificationID"))
        {
            int savedId = PlayerPrefs.GetInt("ShopNotificationID");
            AndroidNotificationCenter.CancelNotification(savedId);
            PlayerPrefs.DeleteKey("ShopNotificationID");
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // Выбираем случайное имя и сообщение
            int nameIndex = UnityEngine.Random.Range(0, Names.Length);
            int messageIndex = UnityEngine.Random.Range(0, Messages.Length);

            // Создаем уведомление
            AndroidNotification notification = new AndroidNotification()
            {
                Title = Names[nameIndex],
                Text = Messages[messageIndex],
                FireTime = DateTime.Now.AddSeconds(PlayerPrefs.GetInt("ShopNotificationSeconds", 0)),
                SmallIcon = "app_icon",
                LargeIcon = "app_icon"
            };

            // Отправляем и сохраняем ID
            int id = AndroidNotificationCenter.SendNotification(notification, "Shop");
            PlayerPrefs.SetInt("CreditsNotificationID", id);
            PlayerPrefs.Save();
        }
        else
        {
            // Игрок вернулся — удаляем уведомление
            if (PlayerPrefs.HasKey("ShopNotificationID"))
            {
                int savedId = PlayerPrefs.GetInt("ShopNotificationID");
                AndroidNotificationCenter.CancelNotification(savedId);
                PlayerPrefs.DeleteKey("ShopNotificationID");
            }
        }
    }
}