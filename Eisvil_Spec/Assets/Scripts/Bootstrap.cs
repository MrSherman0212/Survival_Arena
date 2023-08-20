using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject[] _initializables;

    private void Awake()
    {
        foreach (var item in _initializables)
        {
            IInitializable initializable = item.GetComponent<IInitializable>();
            initializable?.Init();
        }
    }
}
