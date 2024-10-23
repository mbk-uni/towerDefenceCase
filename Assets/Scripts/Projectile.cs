using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour, IProjectile
{
    [Inject] private ProjectileData _projectileData;

    public float Speed => _projectileData.speed;
    public float Damage => _projectileData.damage;

    public void Launch(IEnemy target)
    {
        // Hedefe doğru fırlatma mantığı
    }
}