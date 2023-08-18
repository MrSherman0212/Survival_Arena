using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(CollisionDamage))]
public class EssenceClass : MonoBehaviour
{
    private ObjectPool<EssenceClass> _pool;
    protected EssenceSpawner _spawner;
    [Header("Health")]
    [SerializeField] protected float _maxHealthPoints = 5;
    [SerializeField] protected float _projectileResistance = 5;
    protected HealthSystem _healthSystem;
    [Header("Movement")]
    [SerializeField] protected float _movementSpeed = 2;
    protected Vector2 _movementDirection;
    [Header("Collision")]
    [SerializeField] protected float _collisionDamageAmount = 1;
    protected CollisionDamage _collisionDamage;
    protected Rigidbody2D _rigidbody2D;
    protected Transform _transform;

    public ObjectPool<EssenceClass> ObjectPool { get { return _pool; } }

    public virtual void Init(
        EssenceSpawner spawner,
        float health,
        float speed,
        float damageAmount,
        float projResistance)
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _healthSystem = GetComponent<HealthSystem>();
        _healthSystem.Init();

        _transform = GetComponent<Transform>();
        _spawner = spawner;
        _maxHealthPoints = health;
        _movementSpeed = speed;
        _collisionDamageAmount = damageAmount;
        _projectileResistance = projResistance;
    }

    public virtual void Move()
    {
        _rigidbody2D.velocity = _movementDirection * Time.deltaTime;
    }

    public virtual void DestroyItem() => _pool.Release(this);

    public void SetPool(ObjectPool<EssenceClass> pool) => _pool = pool;
}
