using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnRadius = 5f;
    public int numPrefabsToSpawn = 10;

    private void Start()
    {
        SpawnPrefabs();
    }

    private void SpawnPrefabs()
    {
        for (int i = 0; i < numPrefabsToSpawn; i++)
        {
            Vector3 randomSpawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, randomSpawnPosition, Quaternion.identity);
        }
    }
}
