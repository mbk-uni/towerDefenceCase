using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITower
{
    float FireRate { get; }
    float Range { get; }
    void Fire(IEnemy target);
}
