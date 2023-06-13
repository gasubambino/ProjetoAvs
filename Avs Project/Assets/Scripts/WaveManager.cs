using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public UIManager manager;
    //enemies prefabs
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;

    //spawnpoints
    public Transform[] spawnPoints;

    //wave array
    public Wave[] waves;
    private int currentWaveIndex = 0;

    //check if all enemies of the current wave spawned
    bool allEnemiesSpawned = false;

    void Start()
    {
        StartNextWave();
    }

    void Update()
    {
        if (allEnemiesSpawned == true && !CheckIfEnemiesExist()) //if all enemies of the current wave spawned and there's no enemies alive:
        {
            manager.UpgradeActivate();
            StartNextWave(); //start next wave
            allEnemiesSpawned = false; //set back to false
        }
    }
    private void StartNextWave()
    {
        if (currentWaveIndex < waves.Length) //waves keep going
        {
            StartCoroutine(SpawnWave(waves[currentWaveIndex])); 
            currentWaveIndex++;
        }
        else //all waves concluded
        {
            
        }
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.enemy1Count; i++)
        {
            //spawnpoint
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];
            //instantiate in the new spawnpoint
            Instantiate(enemy1Prefab, spawnPoint.position, spawnPoint.rotation);
            //repeat after the wave's spawnInterval
            yield return new WaitForSeconds(wave.spawnInterval);
        }
        for (int i = 0; i < wave.enemy2Count; i++)
        {
            //same
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];
            Instantiate(enemy2Prefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(wave.spawnInterval);
        }
        allEnemiesSpawned = true;//all the for loops ended 
    }
    bool CheckIfEnemiesExist()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            //there is 1 or more enemies on the scene
            return true;
        }
        else
        {
            //no enemies remaining
            return false;
        }
    }
}

[System.Serializable]
public class Wave
{
    public int enemy1Count;
    public int enemy2Count;
    public float spawnInterval;
}
