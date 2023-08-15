using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamagable
{
    [SerializeField] private float _health = 1;

    public void Damage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private void Die() => Destroy(gameObject);
}
