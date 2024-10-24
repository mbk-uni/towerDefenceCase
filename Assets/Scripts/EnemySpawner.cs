using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [Inject] BasicEnemyFactory basicEnemyFactory;
    [Inject] private EnemySpawnerData _enemySpawnerData;

    float SpawnRadius => _enemySpawnerData.spawnRadius;
    int EnemiesPerWave => _enemySpawnerData.enemiesPerWave;
    public float TimeBetweenWaves => _enemySpawnerData.timeBetweenWaves;
    public float TimeBetweenEnemies => _enemySpawnerData.timeBetweenEnemies;

    public int numberOfWaves;

    private void Start()
    {
        StartCoroutine(SpawnWaves());

        numberOfWaves = 1;
    }

    public IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < EnemiesPerWave; i++)
            {
                Vector3 spawnPosition = GetRandomPositionAroundTower();

                var basicEnemy = basicEnemyFactory.Create();

                basicEnemy.transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);

                
                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(TimeBetweenWaves);

            numberOfWaves++;
        }
    }

    Vector3 GetRandomPositionAroundTower()
    {        
        float angle = Random.Range(0f, Mathf.PI * 2);

        float distance = Random.Range(20f, SpawnRadius);

        float x = Mathf.Cos(angle) * distance;
        float z = Mathf.Sin(angle) * distance;

        Vector3 spawnPos = new Vector3(x, 0, z);

        return spawnPos;
    }
}
