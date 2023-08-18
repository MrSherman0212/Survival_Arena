using UnityEngine;
using UnityEngine.Pool;
using Cinemachine;

public class PlayerSpawner : EssenceSpawner
{
    [SerializeField] private EssenceInput _essenceInput;
    [SerializeField] private CinemachineVirtualCamera[] _virtualCamera;
    private Transform _playerTransform;
    private bool _canSetCamera = true;

    public Transform PlayerTransform { get { return _playerTransform; } }

    public override void Init()
    {
        base.Init();
        SpawnPlayers();
    }

    private void SpawnPlayers()
    {
        for (int i = 0; i < _spawnAmount; i++)
            _pool.Get();
    }

    public override EssenceClass CreateEssence()
    {
        EssenceClass essence = Instantiate(_essencePrefab);
        InitializeEssence(essence);
        essence.SetPool(_pool);
        essence.GetComponent<PlayerController>().EssenceInput = _essenceInput;
        KillEssence(essence);
        return essence;
    }

    public override void PullEssence(EssenceClass essence)
    {
        base.PullEssence(essence);
        _playerTransform = essence.GetComponent<Transform>();
        if (_canSetCamera) SetCameras(_playerTransform);
    }

    private void SetCameras(Transform player)
    {
        foreach (var item in _virtualCamera)
            item.Follow = player.transform;
        _canSetCamera = false;
    }
}
