using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerManager
{
    public List<ITower> towers = new List<ITower>();

    public void AddTower(ITower tower)
    {
        towers.Add(tower);
    }

    public void RemoveTower(ITower tower)
    {
        towers.Remove(tower);
    }

    public ITower GetNearestTower(Vector3 position)
    {
        if (towers.Count == 0)
        {
            return null;
        }

        return towers
            .OrderBy(t => Vector3.Distance(((MonoBehaviour)t).transform.position, position))
            .FirstOrDefault();
    }
}
