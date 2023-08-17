using UnityEngine;

public class EnemySpawner : EssenceSpawner
{
    [Header("Spawn params")]
    [SerializeField] private float _spawnCooldown = 5;
    private float _cooldownTimer = 0;

    private void Update()
    {
        if (_cooldownTimer >= _spawnCooldown)
        {
            _cooldownTimer = 0;
            _pool.Get();
        }
        else _cooldownTimer += Time.deltaTime;
    }
}