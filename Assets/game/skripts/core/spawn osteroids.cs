using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;   // Обычные препятствия
    public GameObject[] specialPrefabs;    // Пасхалка (амогусы)

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;

    private Transform player;

    [Header("Общие настройки")]
    public float spawnDistance = 6f;
    public float rotationSpeedRange = 50f;
    public float spawnHeightOffset = -1f;
    public float xCalibrationOffset = 0f;
    public Vector3 manualCenterOffset = Vector3.zero;
    public int obstaclesCount = 3; // одно значение для всех режимов

    [Header("Обычные препятствия")]
    public float normalSpeed = 2f;
    public Vector2 normalSizeRange = new Vector2(0.5f, 2f);
    public float normalTowardPlayerProbability = 0.15f;
    public float normalMaxDistance = 3f;

    [Header("Амогусы (пасхалка)")]
    public float amogusSpeed = 3f;
    public Vector2 amogusSizeRange = new Vector2(1f, 2.5f);
    public float amogusTowardPlayerProbability = 0.3f;
    public float amogusMaxDistance = 2f;

    private void Start()
    {
        UpdatePlayerReference();
    }

    private void Update()
    {
        UpdatePlayerReference();
    }

    private void UpdatePlayerReference()
    {
        if (s1 && s1.activeInHierarchy) player = s1.transform;
        else if (s2 && s2.activeInHierarchy) player = s2.transform;
        else if (s3 && s3.activeInHierarchy) player = s3.transform;
        else if (s4 && s4.activeInHierarchy) player = s4.transform;
        else if (s5 && s5.activeInHierarchy) player = s5.transform;
    }

    public void SpawnObstacles()
    {
        if (player == null) return;

        bool isAmogusMode = PlayerPrefs.GetInt("fall") == 1;
        GameObject[] currentPrefabs = isAmogusMode ? specialPrefabs : obstaclePrefabs;
        if (currentPrefabs.Length == 0) return;

        float speed = isAmogusMode ? amogusSpeed : normalSpeed;
        Vector2 sizeRange = isAmogusMode ? amogusSizeRange : normalSizeRange;
        float towardProb = isAmogusMode ? amogusTowardPlayerProbability : normalTowardPlayerProbability;
        float maxDist = isAmogusMode ? amogusMaxDistance : normalMaxDistance;

        for (int i = 0; i < obstaclesCount; i++)
        {
            GameObject prefab = currentPrefabs[Random.Range(0, currentPrefabs.Length)];
            Vector3 spawnPosition = player.position + Vector3.forward * spawnDistance + manualCenterOffset;

            Vector2 randomOffset = Random.insideUnitCircle * maxDist;
            spawnPosition += new Vector3(randomOffset.x + xCalibrationOffset, spawnHeightOffset, randomOffset.y);

            GameObject obstacle = Instantiate(prefab, spawnPosition, Quaternion.identity);
            obstacle.transform.localScale *= Random.Range(sizeRange.x, sizeRange.y);

            ObstacleMovement movement = obstacle.AddComponent<ObstacleMovement>();
            movement.speed = speed;
            movement.rotationSpeed = Random.Range(-rotationSpeedRange, rotationSpeedRange);
            movement.direction = DetermineMovementDirection(towardProb);

            Destroy(obstacle, 20f);
        }
    }

    private Vector3 DetermineMovementDirection(float towardProb)
    {
        if (player == null) return Vector3.back;

        if (Random.value < towardProb)
        {
            return (player.position - transform.position).normalized;
        }
        else
        {
            float randomX = Random.Range(-1f, 1f);
            float randomZ = Random.Range(-1f, 1f);
            return new Vector3(randomX, 0f, randomZ).normalized;
        }
    }

    public void SetObstacleCount(int count)
    {
        obstaclesCount = Mathf.Max(0, count);
    }
}

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 2f;
    public float rotationSpeed = 50f;
    public Vector3 direction;

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
