using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Zenject;

public class BasicEnemy : MonoBehaviour, IEnemy
{
    [Inject] private EnemyData _enemyData;
    [Inject] private List<ITower> _towers;
    [Inject] private TowerManager _towerManager;

    public float Speed => _enemyData.speed;
    public float Health { get; set; }
    public float Damage => _enemyData.damage;

    private ITower _targetTower;
    private Transform _targetTransform;

    private void Start()
    {
        Health = _enemyData.health;

        _towerManager.OnTowerAdded += OnTowerAdded;
        _towerManager.OnTowerRemoved += OnTowerRemoved;

        SetTargetTower();
    }

    private void OnDestroy()
    {        
        _towerManager.OnTowerAdded -= OnTowerAdded;
        _towerManager.OnTowerRemoved -= OnTowerRemoved;
    }

    private void OnTowerAdded(ITower tower)
    {
        SetTargetTower();
    }

    
    private void OnTowerRemoved(ITower tower)
    {
        SetTargetTower();
    }

    private void Update()
    {
        if (_targetTower != null)
        {
            Move();
        }
    }

    public void Move()
    {
        if (_targetTransform == null) return;

        Vector3 direction = (_targetTransform.position - transform.position).normalized;
        transform.position += direction * Speed * Time.deltaTime;
    }

    private void SetTargetTower()
    {
        var towers = _towerManager.GetTowers();
        if (towers.Count == 0)
        {
            _targetTower = null;
            _targetTransform = null;
            return;
        }

        
        _targetTower = towers.OrderBy(tower => Vector3.Distance(transform.position, (tower as MonoBehaviour).transform.position)).FirstOrDefault();

        
        if (_targetTower != null)
        {
            _targetTransform = (_targetTower as MonoBehaviour).transform;
        }
    }


    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Attack()
    {

    }
}