using UnityEngine;
using Unity.Notifications.Android;
using System;

public class LongExitNotification : MonoBehaviour
{
    private string[] Names = {"Никита", "Рома", "Алиса"};
    string[] Messages = 
    {
    "Ты куда пропал? Мы тут вообще-то продолжаем миссию.",
    "Системы корабля в режиме ожидания. Возвращайся.",
    "Мы всё ещё на орбите. Было бы неплохо, если бы ты вернулся.",
    "Сигнал от тебя пропал. Это часть плана?",
    "Топливо есть. Корабль готов. Пилот где?",
    "Я начинаю думать, что ты просто бросил нас.",
    "Напоминаю: космос сам себя исследовать не будет.",
    "Эй. Мы всё ещё здесь. И миссия тоже.",
    "Корабль работает. Команда на месте. Не хватает только тебя.",
    "Если это был отпуск — он закончился.",
    "Системы стабильны. Но без пилота мы далеко не улетим.",
    "Возвращайся. Здесь становится слишком тихо."
    };


    void Start()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "default",
            Name = "В отсутствие",
            Importance = Importance.Default,
            Description = "Если игрока нет долгое время в игре",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        // удаляем старые уведомления канала "default"
        for (int i = 1; i <= 3; i++)
        {
            if (PlayerPrefs.HasKey("DefaultNotificationID" + i))
            {
                int savedId = PlayerPrefs.GetInt("DefaultNotificationID" + i);
                AndroidNotificationCenter.CancelNotification(savedId);
                PlayerPrefs.DeleteKey("DefaultNotificationID" + i);
            }
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Debug.Log("Long exit notifications created");

            float[] delays = { 43200, 129600, 155520};

            for (int i = 0; i < delays.Length; i++)
            {
                int NamesInt = UnityEngine.Random.Range(0, Names.Length);
                int MessagesInt = UnityEngine.Random.Range(0, Messages.Length);

                AndroidNotification notification = new AndroidNotification();
                notification.Title = Names[NamesInt];
                notification.Text = Messages[MessagesInt];
                notification.FireTime = DateTime.Now.AddSeconds(delays[i]);
                notification.SmallIcon = "ic_notification";
                notification.LargeIcon = "icon";

                int id = AndroidNotificationCenter.SendNotification(notification, "default");
                PlayerPrefs.SetInt("DefaultNotificationID" + (i + 1), id);
            }

            PlayerPrefs.Save();
        }
        else
        {
            // игрок вернулся — удаляем все уведомления канала "default"
            for (int i = 1; i <= 3; i++)
            {
                if (PlayerPrefs.HasKey("DefaultNotificationID" + i))
                {
                    int savedId = PlayerPrefs.GetInt("DefaultNotificationID" + i);
                    AndroidNotificationCenter.CancelNotification(savedId);
                    PlayerPrefs.DeleteKey("DefaultNotificationID" + i);
                }
            }
        }
    }
}