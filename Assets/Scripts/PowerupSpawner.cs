using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class PowerupSpawner : MonoBehaviour
{
    public List<GameObject> powerupPrefabs;
    public List<float> spawnX;
    public List<Vector3> spawnPositions;
    public GameObject player;
    private int indexSpawnPoint = 0;
    private bool[] hasSpawned;
    public GenericSpawner genericSpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        hasSpawned = new bool[spawnX.Count];
    }

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < spawnX.Count; i++)
        {
            if (!hasSpawned[i] && player.transform.position.x > spawnX[i])
            {
                SpawnRandomPowerup();
                hasSpawned[i] = true;
                break;
            }
        }
    }
    private void SpawnRandomPowerup()
    {
        if (powerupPrefabs.Count == 0 || spawnPositions.Count == 0 || genericSpawner == null)
        {
            return;
        }
        if (indexSpawnPoint >= spawnPositions.Count) { return; }
        int prefabsIndex = UnityEngine.Random.Range(0, powerupPrefabs.Count);
        genericSpawner.Spawn(powerupPrefabs[prefabsIndex], spawnPositions[indexSpawnPoint], Quaternion.identity);
        indexSpawnPoint++;
    }
}
