using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITower
{
    float FireRate { get; }
    float Range { get; }
    float Health { get; set; }

    void Fire(IEnemy target);
    void TakeDamage(float damage);
}
