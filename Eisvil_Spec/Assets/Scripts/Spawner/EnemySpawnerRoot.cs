using UnityEngine;

public class EnemySpawnerRoot : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Vector3 _rotation;

    private void Update()
    {
        RotateRoot();
    }

    private void RotateRoot()
    {
        _transform.Rotate(_rotation * Time.deltaTime);
    }
}
