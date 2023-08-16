using UnityEngine;

public class ShootingWeapon : MonoBehaviour, IInitializable, IShootable
{
    private Transform _transform;
    [SerializeField] private Projectile _bullet;
    [SerializeField] private float _shootCooldown = 5;
    [SerializeField] private TargetArea _targetArea;
    private float _shootCooldownTimer = 0;
    private Vector2 _moveDirection;

    public void Initialize()
    {
        _transform = GetComponent<Transform>();
    }

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

    public void Shoot()
    {
        if (_targetArea.TargetList.Count > 0)
            _transform.right = _targetArea.FindClosest(_transform).position - _transform.position;
        else
            _transform.right = _moveDirection;
        _shootCooldownTimer = 0;
        Projectile projectile = Instantiate(_bullet, _transform.position, _transform.rotation);
        projectile?.Initialize();
    }

    private void CountTimer() => _shootCooldownTimer += Time.deltaTime;
}
