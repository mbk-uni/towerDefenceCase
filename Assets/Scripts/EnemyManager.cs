using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager
{
    private List<IEnemy> enemies = new List<IEnemy>();

    // Kule ekleme
    public void AddEnemy(IEnemy enemy)
    {
        enemies.Add(enemy);
    }

    // Kule çıkarma
    public void RemoveEnemy(IEnemy enemy)
    {
        enemies.Remove(enemy);
    }

    // En yakın kuleyi bul
    public IEnemy GetNearestEnemy(Vector3 position)
    {
        if (enemies.Count == 0)
        {
            return null;
        }

        return enemies
            .OrderBy(t => Vector3.Distance(((MonoBehaviour)t).transform.position, position))
            .FirstOrDefault();
    }
}
