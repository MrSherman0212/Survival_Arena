using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    private ShootingWeapon _gun;
    [SerializeField] private float _damageAmount = 100;
    [SerializeField] private float _speed = 100;
    [SerializeField] private float _lifeTime = 2;
    private float _lifeTimer = 0;
    [SerializeField] private float _penetrationPower = 2;
    [SerializeField] private string[] _contactExeptions;

    [Header("ObjectPool")]
    [SerializeField] protected bool _usePool = true;
    [SerializeField] protected int _spawnAmount = 10;
    protected ObjectPool<Projectile> _pool;

    private Transform _transform;

    public void Init(
        ShootingWeapon shootingWeapon,
        float damageAmount,
        float speed,
        float lifeTime,
        float penetrationPower)
    {
        _lifeTimer = 0;

        _gun = shootingWeapon;
        _damageAmount = damageAmount;
        _speed = speed;
        _lifeTime = lifeTime;
        _penetrationPower = penetrationPower;

        _transform = GetComponent<Transform>();
        _transform.position = _gun.transform.position;
        _transform.rotation = _gun.transform.rotation;
    }

    private void Update()
    {
        CountTimer();
        Move();
    }

    private void Move()
    {
        _transform.position += transform.right * Time.deltaTime * _speed;
    }

    private void CountTimer()
    {
        if (_lifeTimer >= _lifeTime) DestroyProjectile();
        else _lifeTimer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var item in _contactExeptions)
        {
            if (collision.CompareTag(item)) continue;
            else DoDamage(collision);
        }
    }

    private void DoDamage(Collider2D collision)
    {
        IDamagable damagable = collision.GetComponent<IDamagable>();
        IProjectileResistable resistable = collision.GetComponent<IProjectileResistable>();

        if (resistable != null) _penetrationPower -= resistable.ProjectileResistance;
        if (damagable != null) damagable.Damage(_damageAmount);
        if (_penetrationPower <= 0) DestroyProjectile();
    }

    public void SetPool(ObjectPool<Projectile> pool) => _pool = pool;

    public void DestroyProjectile() => _pool.Release(this);
}
