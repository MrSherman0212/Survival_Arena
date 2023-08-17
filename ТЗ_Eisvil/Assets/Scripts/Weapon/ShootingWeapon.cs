using UnityEngine;
using UnityEngine.Pool;

public class ShootingWeapon : MonoBehaviour, IInitializable
{
    private Transform _transform;
    [SerializeField] private TargetArea _targetArea;
    private Vector2 _moveDirection;
    [Header("Values")]
    [SerializeField] private Projectile _bulletPrefab;
    [SerializeField] private float _shootCooldown = 5;
    [SerializeField] private float _projectileDamage = 5;
    [SerializeField] private float _projectileSpeed = 5;
    [SerializeField] private float _projectileLifeTime = 5;
    [SerializeField] private float _projectilePenetrationPower = 5;
    private float _shootCooldownTimer = 0;
    [Header("ObjectPool")]
    [SerializeField] private bool _usePool = true;
    [SerializeField] private int _spawnAmount = 10;
    private ObjectPool<Projectile> _pool;

    public void Init()
    {
        _transform = GetComponent<Transform>();
        _pool = new ObjectPool<Projectile>(CreateProjectile, PullProjectile, KillProjectile, DestroyProjectile, false, 10, 20);
        Spawn();
    }

    public void SetPool(ObjectPool<Projectile> pool) => _pool = pool;

    private void Update()
    {
        CountTimer();
        if (_shootCooldownTimer >= _shootCooldown)
        {
            Shoot();
        }
    }

    public void SetDirection(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnAmount; i++)
        {
            CreateProjectile();
        }
    }

    public void Shoot()
    {
        if (_targetArea.TargetList.Count > 0)
            _transform.right = _targetArea.FindClosest(_transform).position - _transform.position;
        else
            _transform.right = _moveDirection;
        _shootCooldownTimer = 0;
        Projectile projectile = _usePool ? _pool.Get() : Instantiate(_bulletPrefab);
        InitializeProjectile(projectile);
        projectile.SetPool(_pool);
    }

    private Projectile CreateProjectile()
    {
        Projectile projectile = Instantiate(_bulletPrefab);
        InitializeProjectile(projectile);
        KillProjectile(projectile);
        projectile.SetPool(_pool);
        return projectile;
    }

    private void PullProjectile(Projectile projectile)
    {
        projectile.transform.position = _transform.position;
        projectile.gameObject.SetActive(true);
    }

    public virtual void KillProjectile(Projectile projectile)
    {
        if (_usePool) projectile.gameObject.SetActive(false);
        else DestroyProjectile(projectile);
    }

    public virtual void DestroyProjectile(Projectile projectile) => Destroy(projectile.gameObject);

    private void InitializeProjectile(Projectile projectile)
    {
        projectile.Init(this, _projectileDamage, _projectileSpeed, _projectileLifeTime, _projectilePenetrationPower);
    }

    private void CountTimer() => _shootCooldownTimer += Time.deltaTime;
}
