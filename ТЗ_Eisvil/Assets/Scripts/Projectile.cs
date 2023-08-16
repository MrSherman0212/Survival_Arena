using UnityEngine;

public class Projectile : MonoBehaviour, IInitializable
{
    [SerializeField] private float _damageAmount = 100;
    [SerializeField] private float _speed = 100;
    [SerializeField] private float _lifeTime = 2;
    private float _lifeTimer = 0;
    [SerializeField] private float _stoppingPower = 2;
    [SerializeField] private string[] _contactExeptions;

    private Transform _transform;

    public void Initialize()
    {
        _transform = GetComponent<Transform>();
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
        if (_lifeTimer >= _lifeTime)
            Destroy(gameObject);
        else
            _lifeTimer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var item in _contactExeptions)
        {
            if (collision.CompareTag(item))
                continue;
            else
                DoDamage(collision);
        }
    }

    private void DoDamage(Collider2D collision)
    {
        IDamagable damagable = collision.GetComponent<IDamagable>();
        IProjectileResistable resistable = collision.GetComponent<IProjectileResistable>();

        if (resistable != null)
            _stoppingPower -= resistable.ProjectileResistance;
        if (damagable != null)
        {
            damagable.Damage(_damageAmount);
        }
        if (_stoppingPower <= 0)
            Destroy(gameObject);
    }
}
