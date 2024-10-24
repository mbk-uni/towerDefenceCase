using UnityEngine;

[CreateAssetMenu(menuName = "TowerDefense/EnemySpawnerData")]
public class EnemySpawnerData : ScriptableObject
{
    public float spawnRadius;
    public int enemiesPerWave;
    public float timeBetweenWaves;
    public float timeBetweenEnemies;
}