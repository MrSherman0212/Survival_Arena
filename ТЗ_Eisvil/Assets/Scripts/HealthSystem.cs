using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour, IDamagable, IInitializable, IProjectileResistable
{
    [SerializeField] private float _maxHealth = 5;
    [SerializeField] private float _health;
    [SerializeField] private float _projectileResistance = 1;
    [SerializeField] private Slider _healthBar;

    public float ProjectileResistance { get { return _projectileResistance; } }

    public void Initialize()
    {
        _health = _maxHealth;
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _health;
    }

    public void Damage(float damage)
    {
        _health -= damage;
        _healthBar.value = _health;
        if (_health <= 0)
            Die();
    }

    private void Die() => Destroy(gameObject);
}
