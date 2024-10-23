using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    float Speed { get; }
    float Damage { get; }
    void Launch(IEnemy target);
}
