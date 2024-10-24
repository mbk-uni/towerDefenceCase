using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Zenject;
using TMPro;

public class BasicEnemy : MonoBehaviour, IEnemy
{
    [Inject] private EnemyData _enemyData;
    [Inject] private TowerManager _towerManager;
    [Inject] private EnemyManager _enemyManager;

    public float Speed => _enemyData.speed;
    public float Health { get; set; }
    public float Damage => _enemyData.damage;

    public Vector3 Position => transform.position;

    private ITower nearestTower;
    private Transform nearestTowerTransform;

    public TextMeshPro healthText;

    private void Start()
    {
        Health = _enemyData.health;

        FindNearestTower();

        healthText.text = Health.ToString("F0");

        _enemyManager.AddEnemy(this);
    }

    private void Update()
    {
        if (nearestTowerTransform != null)
        {
            Move();
        }
        else
        {
            FindNearestTower();
        }
    }

    private void OnDestroy()
    {
        _enemyManager.RemoveEnemy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        ITower tower = other.gameObject.GetComponent<ITower>();

        if (tower != null)
        {
            tower.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        
        Vector3 direction = (nearestTowerTransform.position - transform.position).normalized;

        
        transform.position += direction * Speed * Time.deltaTime;
    }


    public void TakeDamage(float amount)
    {
        Health -= amount;
        healthText.text = Health.ToString("F0");

        if (Health <= 0)
        {
            Destroy(gameObject);
            _enemyManager.RemoveEnemy(this);
        }
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

    void FindNearestTower()
    {
        nearestTower = _towerManager.GetNearestTower(transform.position);
        if (nearestTower != null)
        {
            nearestTowerTransform = ((MonoBehaviour)nearestTower).transform;
        }
    }
}

public class BasicEnemyFactory : PlaceholderFactory<BasicEnemy>
{

}