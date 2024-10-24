using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    float Speed { get; }
    float Damage { get; }

    Vector3 Target { get; set; }
    Vector3 StartPosition { get; set; }

    void Launch(IEnemy target, Vector3 startPosition);
}
