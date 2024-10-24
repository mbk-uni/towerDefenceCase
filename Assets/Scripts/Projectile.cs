using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour, IProjectile
{
    [Inject] private ProjectileData _projectileData;
    

    public float Speed => _projectileData.speed;
    public float Damage => _projectileData.damage;

    public Vector3 Target { get; set; }
    public Vector3 StartPosition { get; set; }

    private IEnemy _target;

    private Vector3 previousPosition;
    private float stuckTime = 0f;
    private float maxStuckDuration = 0.3f;

    private void Update()
    {
        CheckTheChangePositionValue();

        MoveToTheEnemy();
    }

    public void MoveToTheEnemy()
    {
        if (_target == null || _target.IsDead())
        {
            Destroy(gameObject);
            return;
        }
        
        Vector3 direction = (Target - transform.position).normalized;
        transform.position += direction * Speed * Time.deltaTime;
        
        
    }

    public void Launch(IEnemy target, Vector3 startPosition)
    {
        Target = target.Position;
        StartPosition = startPosition;

        transform.position = StartPosition;

        _target = target;

        previousPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        IEnemy enemy = other.gameObject.GetComponent<IEnemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }

    void CheckTheChangePositionValue()
    {
        if (Vector3.Distance(transform.position, previousPosition) < 0.01f)
        {
            stuckTime += Time.deltaTime;
            if (stuckTime >= maxStuckDuration)
            {
                Destroy(gameObject);
                return;
            }
        }
        else
        {
            stuckTime = 0f;
        }

        previousPosition = transform.position;
    }
}

public class ProjectileFactory : PlaceholderFactory<Projectile>
{

}