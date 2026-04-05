using UnityEngine;
using System.Collections.Generic;

public class BoostSpawner : MonoBehaviour
{
    public GameObject[] boostPrefabs;

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;

    public float spawnDistance = 6f;
    public float spawnHeightOffset = -1f;

    public float minDistanceBetweenBoosts = 2f;
    public float maxDistanceBetweenBoosts = 4f;
    public float spawnInterval = 120f;

    public List<Vector3> obstaclePositions;

    private List<Vector3> activeBoostPositions = new List<Vector3>();

    private Transform player;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBoost), spawnInterval, spawnInterval);
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

    public void SpawnBoost()
    {
        if (boostPrefabs.Length == 0 || player == null) return;

        Vector3 spawnPosition = GenerateValidPosition();
        spawnPosition.y = spawnHeightOffset;

        GameObject randomBoost = boostPrefabs[Random.Range(0, boostPrefabs.Length)];
        GameObject boost = Instantiate(randomBoost, spawnPosition, Quaternion.identity);

        activeBoostPositions.Add(spawnPosition);
        StartCoroutine(RemoveBoostAfterTime(boost, spawnPosition, 10f));
    }

    private IEnumerator<WaitForSeconds> RemoveBoostAfterTime(GameObject boost, Vector3 position, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(boost);
        activeBoostPositions.Remove(position);
    }

    private Vector3 GenerateValidPosition()
    {
        Vector3 position;
        int safetyCounter = 100;

        do
        {
            float offsetX = Random.Range(-maxDistanceBetweenBoosts, maxDistanceBetweenBoosts);
            float offsetZ = Random.Range(-maxDistanceBetweenBoosts, maxDistanceBetweenBoosts);

            position = player.position + Vector3.forward * spawnDistance;
            position.x += offsetX;
            position.z += offsetZ;

        } while ((IsPositionOccupied(position) || IsNearObstacles(position)) && --safetyCounter > 0);

        return position;
    }

    private bool IsPositionOccupied(Vector3 position)
    {
        foreach (var boostPosition in activeBoostPositions)
        {
            if (Vector3.Distance(position, boostPosition) < minDistanceBetweenBoosts)
                return true;
        }

        return false;
    }

    private bool IsNearObstacles(Vector3 position)
    {
        foreach (var obstaclePosition in obstaclePositions)
        {
            if (Vector3.Distance(position, obstaclePosition) < minDistanceBetweenBoosts)
                return true;
        }

        return false;
    }
}
