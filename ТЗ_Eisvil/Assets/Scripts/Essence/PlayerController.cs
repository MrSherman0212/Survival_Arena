public class PlayerController : EssenceClass
{
    private MeleeWeapon _meleeWeapon;
    private ShootingWeapon _gun;
    private EssenceInput _input;

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

        PlayerSpawner playerSpawner = _spawner.GetComponent<PlayerSpawner>();
        _input = playerSpawner.EsInput;
        _meleeWeapon = GetComponentInChildren<MeleeWeapon>();
        _meleeWeapon?.Init();
        _gun = GetComponentInChildren<ShootingWeapon>();
        _gun?.Init();
    }

    private void SetDirection() => _movementDirection = _input.MovementDirection;

    protected override void Move()
    {
        SetDirection();
        _rigidbody2D.velocity = _movementDirection * _movementSpeed;
    }
}
