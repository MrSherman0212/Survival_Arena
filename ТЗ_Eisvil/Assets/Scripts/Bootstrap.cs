using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _playerGameObject;

    private void Awake()
    {
        _playerController?.Initialize();
        _playerGameObject.SetActive(true);
    }
}
