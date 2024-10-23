using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public EnemyData enemyData;
    public TowerData towerData;
    public ProjectileData projectileData;

    public override void InstallBindings()
    {
        // Scriptable Object bağımlılıklarını bağla
        Container.Bind<EnemyData>().FromInstance(enemyData).AsSingle();
        Container.Bind<TowerData>().FromInstance(towerData).AsSingle();
        Container.Bind<ProjectileData>().FromInstance(projectileData).AsSingle();

        // Interface ile implementasyonları bağla
        Container.Bind<IEnemy>().To<BasicEnemy>().AsTransient();
        Container.Bind<ITower>().To<BasicTower>().AsTransient();
        Container.Bind<IProjectile>().To<Projectile>().AsTransient();

        Container.Bind<List<ITower>>().FromComponentsInHierarchy().AsSingle();

        Container.Bind<TowerManager>().FromComponentInHierarchy().AsSingle();
    }

}
