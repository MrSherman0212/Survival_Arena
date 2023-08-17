using UnityEngine;
using Cinemachine;

public class PlayerSpawner : EssenceSpawner
{
    [SerializeField] private EssenceInput _essenceInput;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    public EssenceInput EsInput { get { return _essenceInput; } }
}
