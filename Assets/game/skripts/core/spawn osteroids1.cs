using UnityEngine;

public class ObstaclearSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    public Transform s1;
    public Transform s2;
    public Transform s3;
    public Transform s4;

    private Transform activePlayer;

    public float spawnDistance = 20f;
    public float obstacleSpeed = 1f;
    public float rotationSpeedRange = 30f;
    public float spawnHeightOffset = -1f;
    public float towardPlayerProbability = 0.6f;

    public Vector2 sizeRange = new Vector2(0.9f, 2f);
    public int obstaclesCount = 1;

    public float minDistanceBetweenObstacles = 1f;
    public float maxDistanceBetweenObstacles = 3f;
    public float xCalibrationOffset = 0f;

    private void Update()
    {
        if (s1.gameObject.activeInHierarchy) activePlayer = s1;
        else if (s2.gameObject.activeInHierarchy) activePlayer = s2;
        else if (s3.gameObject.activeInHierarchy) activePlayer = s3;
        else if (s4.gameObject.activeInHierarchy) activePlayer = s4;
    }

    public void SpawnObstaclesar()
    {
        if (obstaclePrefabs.Length == 0 || activePlayer == null) return;

        for (int i = 0; i < obstaclesCount; i++)
        {
            GameObject randomObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = activePlayer.position + activePlayer.forward * spawnDistance;

            float randomOffsetX = Random.Range(minDistanceBetweenObstacles, maxDistanceBetweenObstacles);
            float randomOffsetZ = Random.Range(minDistanceBetweenObstacles, maxDistanceBetweenObstacles);

            spawnPosition.x += (randomOffsetX + xCalibrationOffset) * (i % 2 == 0 ? 1 : -1);
            spawnPosition.z += randomOffsetZ * (i % 2 == 0 ? 1 : -1);
            spawnPosition.y = spawnHeightOffset;

            GameObject obstacle = Instantiate(randomObstacle, spawnPosition, Quaternion.identity);

            float randomSize = Random.Range(sizeRange.x, sizeRange.y);
            obstacle.transform.localScale *= randomSize;

            Vector3 direction = DetermineMovementDirection(activePlayer);

            ObstaclearMovement movement = obstacle.AddComponent<ObstaclearMovement>();
            movement.speed = obstacleSpeed;
            movement.rotationSpeed = Random.Range(-rotationSpeedRange, rotationSpeedRange);
            movement.direction = direction;

            Destroy(obstacle, 20f);
        }
    }

    private Vector3 DetermineMovementDirection(Transform target)
    {
        if (Random.value < towardPlayerProbability)
        {
            return (target.position - transform.position).normalized;
        }
        else
        {
            float randomX = Random.Range(-0.2f, 0.2f);
            float randomZ = Random.Range(-0.2f, 0.2f);
            return new Vector3(randomX, 0f, randomZ).normalized;
        }
    }
}

public class ObstaclearMovement : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 10f;
    public Vector3 direction;

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
