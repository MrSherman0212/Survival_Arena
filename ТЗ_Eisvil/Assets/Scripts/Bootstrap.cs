using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject[] _initializables;
    [SerializeField] private GameObject _playerGameObject;

    private void Awake()
    {
        foreach (var item in _initializables)
        {
            IInitializable initializable = item.GetComponent<IInitializable>();
            initializable?.Initialize();
        }
        _playerGameObject.SetActive(true);
    }
}
