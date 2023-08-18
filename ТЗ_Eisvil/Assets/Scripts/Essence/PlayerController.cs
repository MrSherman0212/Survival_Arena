using UnityEngine;

public class PlayerController : EssenceClass
{
    private MeleeWeapon _meleeWeapon;
    private ShootingWeapon _gun;
    private EssenceInput _input;

    public EssenceInput EssenceInput { set { _input = value; } }

    public override void Init(
        EssenceSpawner spawner,
        float health,
        float speed,
        float damageAmount,
        float projResistance)
    {
        base.Init(
            _spawner,
            _maxHealthPoints,
            _movementSpeed,
            _collisionDamageAmount,
            _projectileResistance);

        _meleeWeapon = GetComponentInChildren<MeleeWeapon>();
        _meleeWeapon?.Init();
        _gun = GetComponentInChildren<ShootingWeapon>();
        _gun?.Init();
    }

    private void SetDirection() => _movementDirection = _input.MovementDirection;

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        SetDirection();
        if (_input.MovementDirection.x != 0 || _input.MovementDirection.y != 0)
            _gun.SetDirection(_movementDirection);
        _rigidbody2D.velocity = _movementDirection * _movementSpeed;
    }
}
