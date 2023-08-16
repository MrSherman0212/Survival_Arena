using UnityEngine;

public class EnemyController : MonoBehaviour, IInitializable, IMovable
{
    private Vector2 _movementDirection;

    public Vector2 MoveDirection { get { return _movementDirection; } }

    public void Initialize()
    {
        
    }

    public void Move()
    {

    }
}
