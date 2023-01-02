using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRange = 9.5f; // Value for the random range below..

    public int enemyCounter; // Counts enemies still alive..

    public int waveNumber = 1; // Will spawn enemies based on value..

    // Start is called before the first frame update
    void Start()
    {
        SpawnWaves(waveNumber); // Spawns the waves of enemies that will be generated through time..
        SpawnPowerups();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCounter = FindObjectsOfType<Enemy>().Length; // Will find enemies..

        // & if enemies total to zero, spawn more..
        if (enemyCounter == 0)
        {
            waveNumber++; // Adds 1 enemy per wave we defeat..
            SpawnWaves(waveNumber);
            SpawnPowerups();
        }
    }

    void SpawnPowerups()
    {
        Instantiate(powerupPrefab, GenerateRandomSpawnPoint(), powerupPrefab.transform.rotation);
    }

    void SpawnWaves(int enemiestoSpawn) // enemies to Spawn represents the enemies being spawned..
    {
        for (int i = 0; i < enemiestoSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomSpawnPoint(), enemyPrefab.transform.rotation);
        }
    }
    
    // Create a new method for a Vector3...
    private Vector3 GenerateRandomSpawnPoint()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange); // Random range of coordinates for X
        float spawnPosZ = Random.Range(-spawnRange, spawnRange); // Random range of coordinates for Z
        Vector3 spawnPositions = new Vector3(spawnPosX, 0, spawnPosZ); // The New Spawn Positions..

        return spawnPositions; // We will use this so it will return the results of the Vector3 variable above..    
    }
}
