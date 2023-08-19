using UnityEngine;
using System.Collections.Generic;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private List<string> _contactExeptions;
    [SerializeField] private float _damageAmount = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool CanContact = false;
        foreach (var item in _contactExeptions)
        {
            if (collision.gameObject.CompareTag(item))
            {
                CanContact = false;
                continue;
            }
            CanContact = true;
        }
        if (CanContact) DoDamage(collision);
    }

    private void DoDamage(Collision2D collision)
    {
        IDamagable damagable = collision.collider.GetComponent<IDamagable>();

        if (damagable != null)
        {
            damagable.Damage(_damageAmount);
        }
    }
}
