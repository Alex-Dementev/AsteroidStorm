using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

    private Transform player; // Текущий активный скин

    public float spawnDistance = 6f;
    public float obstacleSpeed = 2f;
    public float rotationSpeedRange = 50f;
    public float spawnHeightOffset = -1f;
    public float towardPlayerProbability = 0.6f;
    public Vector2 sizeRange = new Vector2(0.5f, 2f);
    public int obstaclesCount = 3;
    public float minDistanceBetweenObstacles = 1f;
    public float maxDistanceBetweenObstacles = 3f;
    public float xCalibrationOffset = 0f;

    private void Start()
    {
        UpdatePlayerReference();
    }

    private void Update()
    {
        // В случае смены скина — постоянно обновляем ссылку
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
            GameObject randomObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            Vector3 spawnPosition = player.position + Vector3.forward * spawnDistance;

            float randomOffsetX = Random.Range(minDistanceBetweenObstacles, maxDistanceBetweenObstacles);
            float randomOffsetZ = Random.Range(minDistanceBetweenObstacles, maxDistanceBetweenObstacles);

            spawnPosition.x += (randomOffsetX + xCalibrationOffset) * (i % 2 == 0 ? 1 : -1);
            spawnPosition.z += randomOffsetZ * (i % 2 == 0 ? 1 : -1);
            spawnPosition.y = spawnHeightOffset;

            GameObject obstacle = Instantiate(randomObstacle, spawnPosition, Quaternion.identity);

            float randomSize = Random.Range(sizeRange.x, sizeRange.y);
            obstacle.transform.localScale *= randomSize;

            Vector3 direction = DetermineMovementDirection();
            ObstacleMovement movement = obstacle.AddComponent<ObstacleMovement>();
            movement.speed = obstacleSpeed;
            movement.rotationSpeed = Random.Range(-rotationSpeedRange, rotationSpeedRange);
            movement.direction = direction;

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
