using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public EnemyData enemyData;
    public TowerData towerData;
    public ProjectileData projectileData;
    public EnemySpawnerData enemySpawnerData;

    public GameObject basicTowerPrefab;
    public GameObject basicEnemyPrefab;
    public GameObject projectilePrefab;

    public override void InstallBindings()
    {
        
        Container.Bind<EnemyData>().FromInstance(enemyData).AsSingle();
        Container.Bind<TowerData>().FromInstance(towerData).AsSingle();
        Container.Bind<ProjectileData>().FromInstance(projectileData).AsSingle();
        Container.Bind<EnemySpawnerData>().FromInstance(enemySpawnerData).AsSingle();

        Container.Bind<IEnemy>().To<BasicEnemy>().AsTransient();
        Container.Bind<ITower>().To<BasicTower>().AsTransient();
        Container.Bind<IProjectile>().To<Projectile>().AsTransient();

        Container.Bind<EnemySpawner>().FromComponentsInHierarchy().AsSingle();

        Container.Bind<TowerManager>().AsSingle().NonLazy();
        Container.Bind<EnemyManager>().AsSingle().NonLazy();

        Container.BindFactory<BasicTower, BasicTowerFactory>().FromComponentInNewPrefab(basicTowerPrefab);
        Container.BindFactory<BasicEnemy, BasicEnemyFactory>().FromComponentInNewPrefab(basicEnemyPrefab);
        Container.BindFactory<Projectile, ProjectileFactory>().FromComponentInNewPrefab(projectilePrefab);
    }

}
