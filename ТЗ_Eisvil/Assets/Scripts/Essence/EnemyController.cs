using UnityEngine;

public class EnemyController : EssenceClass
{
    private Transform _playerTransform;

    public Transform PlayerTransform { set { _playerTransform = value; } }

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        SetDirection();
        _rigidbody2D.velocity = _movementDirection * _movementSpeed;
    }

    private void SetDirection()
    {
        _movementDirection = (_playerTransform.position - _transform.position).normalized;
    }
}
