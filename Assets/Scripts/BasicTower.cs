using UnityEngine;
using Zenject;

public class BasicTower : MonoBehaviour, ITower
{
    [Inject] private TowerData _towerData;

    public float FireRate => _towerData.fireRate;
    public float Range => _towerData.range;

    public void Fire(IEnemy target)
    {
        // Mermi fırlatma mantığı
    }
}