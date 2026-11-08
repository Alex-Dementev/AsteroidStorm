using System;

public static class BoxEvents
{
    // Событие, которое вызывается при покупке/изменении статуса бокса
    public static event Action OnBoxesUpdated;

    // Метод для вызова события у всех подписчиков
    public static void TriggerBoxesUpdated()
    {
        OnBoxesUpdated?.Invoke();
    }
}