using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerManager
{
    public List<ITower> towers = new List<ITower>();

    // Kule ekleme
    public void AddTower(ITower tower)
    {
        towers.Add(tower);
    }

    // Kule çıkarma
    public void RemoveTower(ITower tower)
    {
        towers.Remove(tower);
    }

    // En yakın kuleyi bul
    public ITower GetNearestTower(Vector3 position)
    {
        if (towers.Count == 0)
        {
            return null; // Kule yoksa null döndür
        }

        // En yakın kuleyi bulmak için mesafeyi sırala
        return towers
            .OrderBy(t => Vector3.Distance(((MonoBehaviour)t).transform.position, position))
            .FirstOrDefault();
    }
}
