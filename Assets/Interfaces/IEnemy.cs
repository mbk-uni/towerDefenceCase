using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    float Speed { get; }
    float Health { get; set; }
    float Damage { get; }
    Vector3 Position { get; }

    void Move();
    void TakeDamage(float amount);
    bool IsDead();
}
