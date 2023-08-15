public interface IInitializable
{
    void Initialize();
}

public interface IMovable
{
    void Move();
}

public interface IDamagable
{
    void Damage(float damage);
}

public interface IShootable
{
    void Shoot();
}