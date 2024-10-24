using UnityEngine;
using Zenject;
using System.Collections;
using System.Linq;
using TMPro;
using System.Collections.Generic;

public class BasicTower : MonoBehaviour, ITower
{
    [Inject] private TowerData _towerData;
    [Inject] private TowerManager _towerManager;
    [Inject] private ProjectileFactory _projectileFactory;
    [Inject] private EnemyManager _enemyManager;

    public float FireRate => _towerData.fireRate;
    public float Range => _towerData.range;
    public float Health { get; set; }

    private IEnemy nearestEnemy;
    //private Transform nearestEnemyTransform;

    public TextMeshPro healthText;

    float timer;

    private void Start()
    {
        Health = _towerData.health;

        _towerManager.AddTower(this);

        healthText.text = Health.ToString("F0");

        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= FireRate)
        {
            FindNearestEnemy();

            if (nearestEnemy != null && Vector3.Distance(transform.position, nearestEnemy.Position) <= Range)
            {
                
                Fire(nearestEnemy);
                timer = 0f;
            }
        }
    }

    private void OnDestroy()
    {
        _towerManager.RemoveTower(this);
    }

    public void Fire(IEnemy target)
    {
        
        var projectile = _projectileFactory.Create();

        projectile.Launch(target, transform.position);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        healthText.text = Health.ToString("F0");

        if (Health <= 0)
        {
            Destroy(gameObject);
            _towerManager.RemoveTower(this);
        }
    }

    void FindNearestEnemy()
    {
        nearestEnemy = _enemyManager.GetNearestEnemy(transform.position);
        //if (nearestEnemy != null)
        //{
        //    nearestEnemyTransform = ((MonoBehaviour)nearestEnemy).transform;
        //}
    }
}

public class BasicTowerFactory : PlaceholderFactory<BasicTower>
{

}