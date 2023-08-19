using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour, IDamagable, IInitializable, IProjectileResistable
{
    [SerializeField] private float _maxHealth = 5;
    [SerializeField] private float _health;
    [SerializeField] private float _projectileResistance = 1;
    [SerializeField] private Slider _healthBar;
    private EssenceClass _essence;

    public float MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
    public float ProjectileResistance { get { return _projectileResistance; } }

    public void Init()
    {
        _health = _maxHealth;
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _health;
        _essence = GetComponent<EssenceClass>();
    }

    public void Damage(float damage)
    {
        _health -= damage;
        _healthBar.value = _health;
        if (_health <= 0)
            Die();
    }

    public virtual void Die() => _essence.DestroyItem();
}
