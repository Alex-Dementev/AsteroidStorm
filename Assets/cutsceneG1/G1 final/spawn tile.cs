using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawntile : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public Transform player;

    public float spawnY = -12f; // <-- регулируемая высота спавна

    private float spawnZ = 50f;
    private float tileLength = 500f;
    private int tilesOnScreen = 3;
    private float safeZone = 550f;

    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    void Update()
    {
        if (player.position.z - safeZone > (spawnZ - tilesOnScreen * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteOldestTile();
        }
    }

    void SpawnTile(int index)
    {
        Vector3 spawnPosition = new Vector3(0, spawnY, spawnZ);
        GameObject go = Instantiate(tilePrefabs[index], spawnPosition, Quaternion.identity);
        activeTiles.Add(go);
        spawnZ += tileLength;
    }

    void DeleteOldestTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
