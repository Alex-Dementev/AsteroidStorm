using UnityEngine;
using Unity.Notifications.Android;
using System;

public class CreditsNotification : MonoBehaviour
{
    private string[] Names = { "Никита", "Рома", "Алиса" };
    private string[] Messages =
    {
        "Осложнения по кредиту уже начались. Нужно действовать.",
        "Кредиторы начинают давить прямо сейчас. Не откладывай.",
        "Проблемы с долгом активны. Срочно займись оплатой.",
        "Система фиксирует осложнения. Решения ждать нельзя.",
        "Долг не исчез, а последствия уже проявляются.",
        "Осложнения усиливаются. Нужна немедленная реакция.",
        "Кредиторы на связи. Ситуация накаляется.",
        "Состояние задолженности критическое. Действовать надо.",
        "Проблемы по кредиту уже на горизонте. Не медли.",
        "Система предупреждает: последствия уже идут.",
        "Сложности с кредитом уже начались. Срочно вмешивайся.",
        "Кредиторы начали действовать. Осложнения очевидны.",
        "Ситуация по долгу обостряется. Не откладывай решение."
    };

    void Start()
    {
        // Регистрируем канал
        var channel = new AndroidNotificationChannel()
        {
            Id = "Credits",
            Name = "Кредиты",
            Importance = Importance.Default,
            Description = "Напоминание о кредитах",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        // Удаляем старое уведомление, если есть
        if (PlayerPrefs.HasKey("CreditsNotificationID"))
        {
            int savedId = PlayerPrefs.GetInt("CreditsNotificationID");
            AndroidNotificationCenter.CancelNotification(savedId);
            PlayerPrefs.DeleteKey("CreditsNotificationID");
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            if(PlayerPrefs.GetInt("CreditsActivee", 0) == 1)
            {
                // Выбираем случайное имя и сообщение
                int nameIndex = UnityEngine.Random.Range(0, Names.Length);
                int messageIndex = UnityEngine.Random.Range(0, Messages.Length);

                int Seconds = PlayerPrefs.GetInt("CreditsNotificationSeconds", 0);
                if(Seconds == 0)
                    Seconds = 21600;

                // Создаем уведомление
                AndroidNotification notification = new AndroidNotification()
                {
                    Title = Names[nameIndex],
                    Text = Messages[messageIndex],
                    FireTime = DateTime.Now.AddSeconds(Seconds),
                    SmallIcon = "app_icon",
                    LargeIcon = "app_icon"
                };

                // Отправляем и сохраняем ID
                int id = AndroidNotificationCenter.SendNotification(notification, "Credits");
                PlayerPrefs.SetInt("CreditsNotificationID", id);
                PlayerPrefs.Save();
            }
        }
        else
        {
            // Игрок вернулся — удаляем уведомление
            if (PlayerPrefs.HasKey("CreditsNotificationID"))
            {
                int savedId = PlayerPrefs.GetInt("CreditsNotificationID");
                AndroidNotificationCenter.CancelNotification(savedId);
                PlayerPrefs.DeleteKey("CreditsNotificationID");
            }
        }
    }
}