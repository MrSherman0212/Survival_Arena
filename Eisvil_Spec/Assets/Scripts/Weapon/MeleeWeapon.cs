using UnityEngine;

public class MeleeWeapon : MonoBehaviour, IInitializable
{
    [SerializeField] private float _rotationSpeed = 1;
    private Transform _transform;

    public void Init()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.Rotate(0, 0, -_rotationSpeed * Time.deltaTime);
    }
}
