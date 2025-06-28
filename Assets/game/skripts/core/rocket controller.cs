
using UnityEngine;

public class RocketUniversalControl : MonoBehaviour
{
    public float initialZSpeed = 2f; // Начальная скорость по оси Z
    public float zSpeedIncrement = 1f; // Увеличение скорости по Z каждые 2 секунды
    public float zSpeedUpdateInterval = 2f; // Интервал увеличения скорости по Z
    public float xRange = 10f; // Максимальное отклонение по X
    public float sensitivity = 1f; // Чувствительность управления
    public float smoothFactor = 0.1f; // Коэффициент сглаживания движения
    public Vector3 calibrationOffset = Vector3.zero; // Смещение для калибровки позиции курсора

    private Camera mainCamera; // Камера для преобразования координат
    public float zSpeed; // Текущая скорость по оси Z
    private float nextZSpeedUpdateTime; // Время следующего обновления скорости
    private Vector3 targetPosition; // Целевая позиция для ракеты

    void Start()
    {
        mainCamera = Camera.main;
        zSpeed = initialZSpeed; // Устанавливаем начальную скорость по Z
        nextZSpeedUpdateTime = Time.time + zSpeedUpdateInterval; // Первое обновление скорости
        targetPosition = transform.position; // Инициализация начальной позиции
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;

        // Проверка ввода (палец или мышь)
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            Vector2 inputPosition;

            // Получаем позицию пальца или мыши
            if (Input.touchCount > 0)
            {
                inputPosition = Input.GetTouch(0).position;
            }
            else
            {
                inputPosition = Input.mousePosition;
            }

            // Преобразуем экранные координаты в мировые
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, mainCamera.transform.position.y));

            // Применяем калибровку (корректируем позицию курсора)
            worldPosition += calibrationOffset;

            // Применяем чувствительность и ограничиваем диапазон X
            float clampedX = Mathf.Clamp(worldPosition.x * sensitivity, -xRange, xRange);

            // Устанавливаем целевую позицию ракеты
            targetPosition = new Vector3(clampedX, currentPosition.y, currentPosition.z);
        }

        // Плавно двигаем ракету к целевой позиции по X
        currentPosition.x = Mathf.Lerp(currentPosition.x, targetPosition.x, smoothFactor);

        // Автоматическое движение по оси Z
        currentPosition.z += zSpeed * Time.deltaTime;

        // Применяем новое положение
        transform.position = currentPosition;

        // Увеличение скорости по оси Z каждые zSpeedUpdateInterval секунд
        if (Time.time >= nextZSpeedUpdateTime)
        {
            zSpeed += zSpeedIncrement;
            nextZSpeedUpdateTime = Time.time + zSpeedUpdateInterval;
        }
    }
}