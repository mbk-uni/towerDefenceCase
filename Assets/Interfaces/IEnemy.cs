using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    float Speed { get; }
    float Health { get; set; }
    float Damage { get; }

    void Move();
    void TakeDamage(float amount);
    void Attack();
}
