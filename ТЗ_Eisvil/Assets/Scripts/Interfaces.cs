using UnityEngine;

public interface IInitializable
{
    void Initialize();
}

public interface IMovable
{
    Vector2 MoveDirection { get; }
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

public interface IProjectileResistable
{
    float ProjectileResistance { get; }
}