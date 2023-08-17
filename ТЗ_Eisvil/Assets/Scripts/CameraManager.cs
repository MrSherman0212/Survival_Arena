using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float _medTiming = 1;
    [SerializeField] private GameObject _mediumCamera;
    [SerializeField] private float _farTiming = 70;
    [SerializeField] private GameObject _farCamera;

    private void Start()
    {
        StartCoroutine(EnableCameras());
    }

    private IEnumerator EnableCameras()
    {
        yield return new WaitForSeconds(_medTiming);
        _mediumCamera.SetActive(true);
        yield return new WaitForSeconds(_farTiming);
        _farCamera.SetActive(true);
    }
}
