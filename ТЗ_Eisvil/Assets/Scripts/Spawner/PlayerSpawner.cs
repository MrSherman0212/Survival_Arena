using UnityEngine;
using UnityEngine.Pool;
using Cinemachine;

public class PlayerSpawner : EssenceSpawner
{
    [SerializeField] private EssenceInput _essenceInput;
    [SerializeField] private CinemachineVirtualCamera[] _virtualCamera;
    private Transform _playerTransform;

    public Transform PlayerTransform { get { return _playerTransform; } }

    public override void Init()
    {
        base.Init();
        _pool.Get();
    }

    public override EssenceClass CreateEssence()
    {
        EssenceClass essence = Instantiate(_essencePrefab);
        InitializeEssence(essence);
        essence.SetPool(_pool);
        KillEssence(essence);
        essence.GetComponent<PlayerController>().EssenceInput = _essenceInput;
        _playerTransform = essence.GetComponent<Transform>();
        SetCameras(_playerTransform);
        return essence;
    }

    private void SetCameras(Transform player)
    {
        foreach (var item in _virtualCamera)
            item.Follow = player.transform;
    }
}
