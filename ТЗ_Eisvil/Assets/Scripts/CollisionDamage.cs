using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private float _damageAmount = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damagable = collision.collider.GetComponent<IDamagable>();

        if (damagable != null)
        {
            damagable.Damage(_damageAmount);
        }
    }
}
