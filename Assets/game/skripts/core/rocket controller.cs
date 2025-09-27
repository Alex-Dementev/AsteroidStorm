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
                Vector2 inputPosition = Input.touchCount > 0
                                        ? (Vector2)Input.GetTouch(0).position
                                        : (Vector2)Input.mousePosition;

                // Корректное преобразование экранных координат в мировые
                float distanceToCamera = transform.position.z - mainCamera.transform.position.z;
                Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, distanceToCamera));
                worldPosition += calibrationOffset;

                targetX = Mathf.Clamp(worldPosition.x * sensitivity, -xRange, xRange);
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