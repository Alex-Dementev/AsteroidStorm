using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

    private Transform player;

    public float spawnDistance = 6f;
    public float obstacleSpeed = 2f;
    public float rotationSpeedRange = 50f;
    public float spawnHeightOffset = -1f;
    public float towardPlayerProbability = 0.15f; // Снижено до 15%
    public Vector2 sizeRange = new Vector2(0.5f, 2f);
    public int obstaclesCount = 3;
    public float minDistanceBetweenObstacles = 1f;
    public float maxDistanceBetweenObstacles = 3f;
    public float xCalibrationOffset = 0f;

    public Vector3 manualCenterOffset = Vector3.zero; // Центр рассеивания задаётся вручную

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
    }

    public void SpawnObstacles()
    {
        if (obstaclePrefabs.Length == 0 || player == null) return;

        for (int i = 0; i < obstaclesCount; i++)
        {
            GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = player.position + Vector3.forward * spawnDistance + manualCenterOffset;

            Vector2 randomOffset = Random.insideUnitCircle * maxDistanceBetweenObstacles;
            spawnPosition += new Vector3(randomOffset.x + xCalibrationOffset, spawnHeightOffset, randomOffset.y);

            GameObject obstacle = Instantiate(prefab, spawnPosition, Quaternion.identity);
            obstacle.transform.localScale *= Random.Range(sizeRange.x, sizeRange.y);

            ObstacleMovement movement = obstacle.AddComponent<ObstacleMovement>();
            movement.speed = obstacleSpeed;
            movement.rotationSpeed = Random.Range(-rotationSpeedRange, rotationSpeedRange);
            movement.direction = DetermineMovementDirection();

            Destroy(obstacle, 21f);
        }
    }

    private Vector3 DetermineMovementDirection()
    {
        if (player == null) return Vector3.back;

        if (Random.value < towardPlayerProbability)
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

    public int ObstacleCount
    {
        get => obstaclesCount;
        set => obstaclesCount = Mathf.Max(0, value);
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
