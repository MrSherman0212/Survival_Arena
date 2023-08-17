using UnityEngine;

public class EnemySpawner : EssenceSpawner
{
    [Header("Spawn params")]
    [SerializeField] private float _spawnCooldown = 5;
    private float _cooldownTimer = 0;
    [SerializeField] private bool _canSpawn = true;
    [SerializeField] private PlayerSpawner _playerSpawner;

    private void Update()
    {
        if (_cooldownTimer >= _spawnCooldown && _canSpawn)
        {
            _cooldownTimer = 0;
            _pool.Get();
        }
        else _cooldownTimer += Time.deltaTime;
    }

    public override EssenceClass CreateEssence()
    {
        EssenceClass essence = Instantiate(_essencePrefab);
        InitializeEssence(essence);
        essence.SetPool(_pool);
        essence.GetComponent<EnemyController>().PlayerTransform = _playerSpawner.PlayerTransform;
        _pool.Release(essence);
        return essence;
    }
}