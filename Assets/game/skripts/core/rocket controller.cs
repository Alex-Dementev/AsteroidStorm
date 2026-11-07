using UnityEngine;

public class RocketUniversalControl : MonoBehaviour
{
    [Header("Z Movement")]
    public float initialZSpeed = 2f;
    public float zSpeedIncrement = 1f;
    public float zSpeedUpdateInterval = 2f;

    [Header("X Movement")]
    public float xRange = 10f;
    public float sensitivity = 1f;
    public float intensityMultiplier = 4f;
    public float gravityFactor = 0.5f;

    [Header("Calibration")]
    public Vector3 calibrationOffset = Vector3.zero;

    private Camera mainCamera;
    public float zSpeed;
    private float nextZSpeedUpdateTime;
    private float targetX;

    [Header("X Movement Offset")]
    public float xOffset = 1f; // смещение вправо

    [Header("Ignore UI Area Thresholds")]
    [Range(0f, 0.5f)] public float ignoreBottomPercent = 0.15f; // 15% снизу
    [Range(0f, 0.5f)] public float ignoreRightPercent = 0.33f;  // 33% справа
    [Range(0f, 0.5f)] public float ignoreTopPercent = 0.10f;   // 7% сверху


    void Start()
    {
        mainCamera = Camera.main;
        zSpeed = initialZSpeed;
        nextZSpeedUpdateTime = Time.time + zSpeedUpdateInterval;
        targetX = transform.position.x;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;

        // Ввод
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            Vector2 inputPosition = Input.touchCount > 0 ? (Vector2)Input.GetTouch(0).position : (Vector2)Input.mousePosition;

            // Проверка: правый нижний угол (15% снизу, 33% справа) ИЛИ верхняя полоса (7% сверху)
            bool isBottomRight = inputPosition.x >= Screen.width * (1f - ignoreRightPercent) && 
                                inputPosition.y <= Screen.height * ignoreBottomPercent;

            bool isTopBar = inputPosition.y >= Screen.height * (1f - ignoreTopPercent);

            bool isInIgnoredArea = isBottomRight || isTopBar;

            if (!isInIgnoredArea)
            {
                // Корректное преобразование экранных координат в мировые
                float distanceToCamera = transform.position.z - mainCamera.transform.position.z;
                Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, distanceToCamera));
                worldPosition += calibrationOffset;

                targetX = Mathf.Clamp(worldPosition.x * sensitivity + xOffset, -xRange + xOffset, xRange + xOffset);
            }
        }

        // Движение по X без возврата
        float deltaX = targetX - currentPosition.x;
        currentPosition.x += deltaX * intensityMultiplier * gravityFactor;

        // Движение по Z
        currentPosition.z += zSpeed * Time.deltaTime;

        transform.position = currentPosition;

        // Увеличение скорости по Z
        if (Time.time >= nextZSpeedUpdateTime)
        {
            zSpeed += zSpeedIncrement;
            nextZSpeedUpdateTime = Time.time + zSpeedUpdateInterval;
        }
    }
}