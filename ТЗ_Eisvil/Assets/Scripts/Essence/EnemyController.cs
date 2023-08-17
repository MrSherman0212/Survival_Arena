using UnityEngine;

public class EnemyController : EssenceClass
{
    private Transform _playerTransform;

    public Transform PlayerTransform { set { _playerTransform = value; } }

    public override void Move()
    {
        SetDirection(_movementDirection);
        base.Move();
    }

    public override void SetDirection(Vector2 vector2)
    {
        vector2 = _playerTransform.position - _transform.position;
    }
}
