using UnityEngine;

public interface IInitializable
{
    void Init();
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

public interface IProjectileResistable
{
    float ProjectileResistance { get; }
}