
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    public float flyInSpeed = 5f;           // Максимальная скорость при влёте
    public float decelerationDistance = 2f; // Расстояние, на котором начинается замедление
    public Vector3 targetPosition;         // Целевая позиция в меню
    public float maxLaunchSpeed = 10f;     // Максимальная скорость после старта
    public float acceleration = 2f;        // Ускорение после старта
    public float hoverAmplitude = 0.1f;    // Амплитуда покачивания
    public float hoverFrequency = 1f;      // Частота покачивания
    private float currentSpeed = 0f;       // Текущая скорость ракеты
    private Vector3 initialPosition;       // Исходное положение для покачивания
    private bool isFlyingToMenu = true;    // Флаг: летит ли ракета в меню
    private bool isLaunching = false;      // Флаг: стартовала ли ракета
    private bool isHovering = false;       // Флаг: ракета находится в состоянии покоя
    public bool isdelayb = false;
    public float isdelay = 1.8f;

    public Vector3 launchDirection;        // Направление полёта после старта (задаётся через инспектор)

    void Start()
    {
        // Устанавливаем начальное положение ракеты (например, за экраном)
        transform.position = new Vector3(-8f, -5f, 0f);
        initialPosition = transform.position;
    }

    void Update()
    {
        isdelay -= Time.deltaTime;
        if(isdelay <= 0)
        isdelayb = true;

        if (isFlyingToMenu)
        {
            // Расстояние до целевой точки
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

            // Плавное замедление при приближении к цели
            if (distanceToTarget <= decelerationDistance)
            {
                float decelerationFactor = distanceToTarget / decelerationDistance; // Коэффициент замедления (от 1 до 0)
                currentSpeed = Mathf.Lerp(0f, flyInSpeed, decelerationFactor); // Плавное снижение скорости
            }
            else
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, flyInSpeed, acceleration * Time.deltaTime);
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);

            // Проверка: достигли целевой позиции
            if (distanceToTarget < 0.01f)
            {
                isFlyingToMenu = false;
                isHovering = true; // Включаем покачивание
                currentSpeed = 0f; // Останавливаем скорость
                initialPosition = targetPosition; // Для покачивания
            }
        }
        else if (isLaunching)
        {
            // Плавное ускорение при старте
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxLaunchSpeed, acceleration * Time.deltaTime);
            transform.Translate(launchDirection.normalized * currentSpeed * Time.deltaTime);
        }
        else if (isHovering)
        {
            // Покачивание ракеты
            float hoverOffset = Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;
            transform.position = initialPosition + new Vector3(0, hoverOffset, 0);
        }
    }

    // Метод для запуска ракеты (связывается с кнопкой)
    public void LaunchRocket()
    {
        if(isdelayb == true && PlayerPrefs.GetInt("start", 0) == 1)
        {
        isHovering = false; // Отключаем покачивание
        isLaunching = true; // Включаем запуск
        currentSpeed = 0f;  // Сбрасываем текущую скорость перед стартом
        isdelay = 999999;
        }
    }
}